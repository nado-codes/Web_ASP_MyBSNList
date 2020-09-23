import React,{useState,useEffect} from 'react';
import {makeStyles} from '@material-ui/core';
import {Grid, Paper} from '@material-ui/core';
import { sizing } from '@material-ui/system';

import Header from '../Components/Header';
import ListPerson from '../Components/ListPerson'

import axios from 'axios';

const useStyles = makeStyles((theme) => ({
    bgLayer: {
        backgroundColor: '#121212',
    },
    root: {
        flex: 1,
        flexDirection: 'column',
        marginLeft: '5%', 
        textAlign: 'left', 
        width: '500px', 
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
    const [people,setPeople] = useState(undefined);

    useEffect (() =>{
        loadData();
    },[]);
    
    const loadData = async () => {
        try
        {
            const conversationsURL = 'api/conversations';
            const conversationsResponse = await axios(conversationsURL);
            const conversationsData = conversationsResponse.data;
            
            setPeople(conversationsData);
        } catch(error) {
            alert(error.response.data.ExceptionMessage);
            console.log(error);
        }
    }

    return(
      <Grid container direction={'column'} className={classes.bgLayer}>
        <Grid item>
            <h1 className={classes.heading}>Suggested</h1>
            <Paper className={classes.root}>
                {people?.map(x => {
                    return <ListPerson key={x?.id} id={x?.Id} name={x?.Name}/>
                })}
            </Paper>
        </Grid>

        <Grid item>
            <h1 className={classes.heading}>Active Conversations</h1>
            <Paper className={classes.root}>
                <ListPerson id={1} name="Sam"/>
                <ListPerson id={2} name="Alex"/>
                <ListPerson id={3} name="Tom"/>
            </Paper>
        </Grid>
      </Grid>  
    );
}

export default ConversationsView;