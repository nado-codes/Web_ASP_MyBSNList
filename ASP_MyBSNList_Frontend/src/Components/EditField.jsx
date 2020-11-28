import React, {useState, useEffect} from 'react';

import {makeStyles, Box, Typography, IconButton} from '@material-ui/core';

import EditIcon from '@material-ui/icons/Edit';

const useStyles = makeStyles((theme) => ({
    root: {
        height: '30px',
        width: '200px',
        background: 'red',
    },
    text: {
        display: 'inline',
        fontSize: '15px',
    },
    button: {
        fontSize: 12,
    },
    buttonContainer: {
        display: 'inline',
        width: '20px',
        height: '20px',
        background: 'green',
    }
}))

const EditField = (props) => {

    const {theme} = props;
    const classes = useStyles(theme);

    const [showEditButton,setShowEditButton] = useState(false);
    const [isEdit,setIsEdit] = useState(false);

    const handleMouseEnter = () => {
        setShowEditButton(true);
    }

    const handleMouseLeave = () => {
        setShowEditButton(false);
    }

    const handleEditClick = () => {
        setIsEdit(!isEdit);
    }

    return (
        <Box className={classes.root} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
            {!isEdit && (
                <Typography className={classes.text}>
                    {//personData?.[personColumns.Nationality.Id]?.Name ?? 
                    //personColumns.EMPTYORNULL.DisplayName
                    }
                    Example Value
                </Typography>
            )}
            <Box className={classes.buttonContainer}>
                {showEditButton && (
                    <IconButton className={classes.button} onClick={handleEditClick}>
                        <EditIcon/>
                    </IconButton>
                )}
            </Box>
        </Box>
    );
}

export default EditField;