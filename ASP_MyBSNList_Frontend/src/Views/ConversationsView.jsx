import React,{useState} from 'react';
import {makeStyles} from '@material-ui/core';
import {Grid, Paper} from '@material-ui/core';
import { sizing } from '@material-ui/system';

import Header from '../Components/Header';
import ListPerson from '../Components/ListPerson'

const useStyles = makeStyles((theme) => ({
    bgLayer: {
        backgroundColor: '#121212',
    },
    root: {
        display: 'flex',
        flexDirection: 'column',
        marginLeft: '5%', 
        textAlign: 'left', 
        width: '90%', 
        height: '500px',
        padding : '10px',
    },
    heading : {
        color: '#484848',
        marginLeft: '50px',
    },
}));

const ConversationsView = (props) => {
    const classes = useStyles(props);

    console.log(classes.bgLayer);

    return(
      <Grid container direction={'column'} className={classes.bgLayer}>
        <Grid item>
            <Header/>
        </Grid>
        <Grid item>
            <h1 className={classes.heading}>Suggested</h1>
            <Paper className={classes.root}>
                <ListPerson name="Sam"/>
                <ListPerson name="Alex"/>
                <ListPerson name="Tom"/>
            </Paper>
        </Grid>

        <Grid item>
            <h1 className={classes.heading}>Active Conversations</h1>
            <Paper className={classes.root}>
                <ListPerson name="Sam"/>
                <ListPerson name="Alex"/>
                <ListPerson name="Tom"/>
            </Paper>
        </Grid>
      </Grid>  
    );
}

export default ConversationsView;