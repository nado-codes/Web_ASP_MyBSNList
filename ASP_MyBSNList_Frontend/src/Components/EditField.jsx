import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';

import {makeStyles, Box, Typography, IconButton, TextField} from '@material-ui/core';
import Autocomplete from '@material-ui/lab/Autocomplete';

import EditIcon from '@material-ui/icons/Edit';
import axios from 'axios';

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

    const {theme, name, onValueUpdated, dataUrl, defaultColumns} = props;
    const classes = useStyles(theme);

    const [value,setValue] = useState(props.value);

    const [showEditButton,setShowEditButton] = useState(false);
    const [isHover,setIsHover] = useState(false);
    const [isEdit,setIsEdit] = useState(false);

    const [acData,setAcData] = useState([]);

    useEffect(() => {

        const loadData = async () => {
            if(isEdit)
            {
                try
                {
                    const data = (await axios({
                        method:'GET',
                        url: dataUrl,
                        baseURL: '/',
                    })).data;

                    setAcData(data);
                }
                catch(err) {
                    console.error(err);
                }
            }
        }

        loadData();
        
    },[isEdit])
    useEffect(() => 
    {
        window.onkeyup = handleKeyPress;
        //console.log("value updated (ub): "+value);
    },[value])

    const handleWindowClick = (hideOnWindowClick) => {
        
        if(hideOnWindowClick)
            handleUpdateValue();

        //console.log(`window will ${!hideOnWindowClick ? 'not' : ''} be hidden`);
    }

    const handleKeyPress = (e) => {
        
        if(e.code === 'Enter')
            handleUpdateValue();
    }

    const handleUpdateValue = (value) => {
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

        //console.log("mouse enter");

        setIsHover(true);
        
        window.onmousedown = () => {handleWindowClick(false)};
    }

    const handleMouseLeave = () => {
        setShowEditButton(false);

        //console.log("mouse leave");

        setIsHover(false);

        window.onmousedown = () => {handleWindowClick(true)};  
    }

    const handleACChanged = (e,value) => {
        console.log("text: "+e.target.value);
        setValue(value);
        handleUpdateValue(value);
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
                    {acData.includes(value) ? value.Name : defaultColumns.EMPTYORNULL.DisplayName}
                </Typography>
            )}
            {isEdit && (
                <Autocomplete 
                    value={value ? value !== "Unknown " ? value : null : null}
                    options={acData} 
                    id="combo-box-demo"
                    getOptionLabel={(option) => option?.Name ?? ""}
                    style={{ width: 200 }}
                    onChange={handleACChanged}
                    renderInput={(params) => <TextField {...params} />}
                    
                />
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