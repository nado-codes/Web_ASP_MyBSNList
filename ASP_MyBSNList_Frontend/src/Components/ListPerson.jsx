import React, {useState} from 'react';
import {makeStyles} from '@material-ui/core';
import {Grid, Button, Paper} from '@material-ui/core';
import {NavLink} from 'react-router-dom';

import AccountCircleIcon from '@material-ui/icons/AccountCircle';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'row',
        backgroundColor : '#242424',
        padding: '20px',
        paddingBottom: '15px',
        borderRadius : '12px',
        margin: 'auto',
        marginBottom: '5px',
        width: '400px',

        '&:hover': {
            backgroundColor: '#484848',
            color: '#FFF',
        }
    },
    rootLink: {
        textDecoration: 'none',
    },
    container : {
        borderRadius : '12px',
        
    },
    icon : {
        fontSize: 40,
        color: 'white',
    },
    body : {
        verticalAlign: 'middle',
        fontStyle: 'bold',
        color: 'white',
        fontSize: 20,
        marginTop: '2.5px',
        height : '30px',
        marginLeft: '5px',
    },
}));

const ListPerson = (props) => {
    const {theme} = props;
    const classes = useStyles(theme);
    const {id, name} = props;

    return (
        <NavLink to={"/person/"+id} className={classes.rootLink}>
            <Button variant="contained" className={classes.root}>
                <Grid container>  
                    <Grid item style={{flex: 0.075}}>
                        <AccountCircleIcon className={classes.icon}/>
                    </Grid>
                    <Grid item className={classes.body}>
                        <p className={classes.body}>{name}</p>
                    </Grid>
                </Grid>
            </Button>
        </NavLink>
    );
}

export default ListPerson;