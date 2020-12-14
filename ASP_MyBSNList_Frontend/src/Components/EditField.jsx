import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';

import {makeStyles, Box, Typography, IconButton, TextField} from '@material-ui/core';
import Autocomplete from '@material-ui/lab/Autocomplete';

import EditIcon from '@material-ui/icons/Edit';

const useStyles = makeStyles((theme) => ({
    root: {
        position: 'relative',
        width: '200px',
        height: '20px',
    },
    text: {
        marginTop: '4px',
        fontSize: '15px',
        display: 'inline',
    },
    textField: {
        marginTop: '-5px',
    },
    button: {
        position: 'absolute',
        fontSize: 15,
        marginTop: '-5px',
    },
    buttonIcon: {
        fontSize: 15,
        position: 'absolute',
    },
}))

const EditField = (props) => {

    const {theme, name, onValueUpdated} = props;
    const classes = useStyles(theme);

    const [value,setValue] = useState(props.value);

    const [showEditButton,setShowEditButton] = useState(false);
    const [isHover,setIsHover] = useState(false);
    const [isEdit,setIsEdit] = useState(false);

    useEffect(() => 
    {
        window.onkeyup = handleKeyPress;
        console.log("value updated (ub): "+value);
    },[value])

    const handleWindowClick = (hideOnWindowClick) => {
        if(hideOnWindowClick)
            handleUpdateValue();
    }

    const handleKeyPress = (e) => {
        
        if(e.code === 'Enter')
            handleUpdateValue();
    }

    const handleUpdateValue = () => {
        console.log("value updated: "+name+"="+value);
        setIsEdit(false);
        window.onmousedown = undefined;
        window.onkeypress = undefined;
        onValueUpdated(name,value);

        if(isHover)
            setShowEditButton(true);
    }

    const handleMouseEnter = () => {

        if(!isEdit)
            setShowEditButton(true);

        setIsHover(true);
        
        window.onmousedown = () => {handleWindowClick(false)};
    }

    const handleMouseLeave = () => {
        setShowEditButton(false);

        setIsHover(false);

        window.onmousedown = () => {handleWindowClick(true)};  
    }

    const handleTextChanged = (e) => {
        //console.log("text: "+e.target.value);
        setValue(e.target.value);
        
    }

    const handleEditClick = () => {
        setIsEdit(true);
        setShowEditButton(false);
        
        window.onkeyup = handleKeyPress;
    }

    return (
        <Box className={classes.root} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
            {!isEdit && (
                <Typography className={classes.text}>
                    {value}
                </Typography>
            )}
            {isEdit && (
                <Autocomplete/>
                /*<TextField className={classes.textField} onChange={handleTextChanged} value={value}/>*/
                
            )}
            {showEditButton && (
                    <IconButton className={classes.button} onClick={handleEditClick}>
                        <EditIcon className={classes.buttonIcon}/>
                    </IconButton>
            )}
        </Box>
    );
}

EditField.defaultProps = {
    onValueUpdated : () => {}
}

EditField.propTypes = { 
    name : PropTypes.string.isRequired,
}

export default EditField;