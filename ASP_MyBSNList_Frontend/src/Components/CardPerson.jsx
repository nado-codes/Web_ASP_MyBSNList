import React, {useState} from 'react';
import {Paper, Grid, IconButton} from '@material-ui/core';
import {makeStyles} from '@material-ui/core';
import {NavLink} from 'react-router-dom';

import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import DeleteIcon from '@material-ui/icons/Delete';

const useStyles = makeStyles((theme) => ({
    root: {
        width: '150px',
        height: '130px',
        padding: '10px',
    },
    rootPaper: {
        '&:hover': {
            backgroundColor: '#EEE',
        },
    },
    rootButton: {
        textTransform: 'none',
    },
    iconContainer: {
        flex: 0.56,
        textAlign: 'center',
        width: '100%',
        marginBottom: '-15px',
    },
    icon: {
        fontSize: 80,
        color: 'black',
    },
    detailName: {
        width: '100%',
        color: 'black',
        textAlign: 'center',
    },
    detailContainer: {
        flex: 0.43,
        textAlign: 'center',
        width: '100%',
        textOverflow: 'ellipsis',
        overflow: 'hidden',
    },
    HeaderButtonLink: {
        textDecoration : 'none',
    },
}));

const useToolStyles = makeStyles((theme) => ({
    root:
    {
        position: 'absolute',
        
        zIndex: 200,
        marginLeft: '10px',
        marginTop: '10px',
        width: '10px',
        height: '10px',
    },
    toolbarButton: 
    {
        width: '30px',
        height: '30px',
    },
    toolbarButtonIcon: 
    {
        fontSize: 25,
    }
}));

const CardTools = (props) => {
    const {theme} = props;
    const classes = useToolStyles(theme);
    const {
        onMouseEnter, 
        onMouseLeave,
        onDeleteClicked
    } = props;

    const handleDeleteClicked = () => {
        onDeleteClicked?.() ?? handleEmpty();
    }

    const handleEmpty = () => {}

    return <Grid 
            container
            className={classes.root} 
            direction='row' 
            onMouseEnter={onMouseEnter} 
            onMouseLeave={onMouseLeave}
        >
        <IconButton className={classes.toolbarButton} onClick={handleDeleteClicked}>
            <DeleteIcon className={classes.toolbarButtonIcon}/>
        </IconButton>
    </Grid>
}

const CardPerson = (props) => {

    const {
        theme,
        onDeleteClicked,
    } = props;
    const classes = useStyles(theme);
    const safe = false;
    const {
        Id,
        SafeName,
        Name
    } = props?.data;

    const [isShowToolbar,setIsShowToolbar] = useState(false);
    const [isLockNavigation,setIsLockNavigation] = useState(false);

    const showToolbar = () => {
        setIsShowToolbar(true);
    }

    const hideToolbar = () => {
        setIsShowToolbar(false);
    }

    const lockNavigation = () => {
        setIsLockNavigation(true);
    }

    const releaseNavigation = () => {
        setIsLockNavigation(false);
    }

    return (
    <Paper 
        className={classes.rootPaper}
        onMouseEnter={showToolbar} 
        onMouseLeave={hideToolbar}>
        <NavLink to={!isLockNavigation ? `/person/${Id}` : `?`} className={classes.HeaderButtonLink}>
            <Grid container className={classes.rootButton} >
                <Grid container direction={'column'} className={classes.root}>
                    <Grid item className={classes.iconContainer}>
                        <AccountCircleIcon className={classes.icon}/>
                    </Grid>
                    <Grid item className={classes.detailContainer}>
                        <p className={classes.detailName}>{(safe ? SafeName : Name) ?? "Unknown Person"}</p>
                    </Grid>
                </Grid>
                {isShowToolbar && 
                    <CardTools 
                        onMouseEnter={lockNavigation} 
                        onMouseLeave={releaseNavigation}
                        onDeleteClicked={onDeleteClicked}
                    />}
            </Grid>
        </NavLink>
        
    </Paper>);
}

export default CardPerson;