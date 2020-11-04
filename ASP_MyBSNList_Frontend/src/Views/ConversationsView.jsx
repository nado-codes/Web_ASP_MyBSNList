import React,{useState,useEffect,useCallback} from 'react';
import {makeStyles} from '@material-ui/core';
import {Grid, Paper} from '@material-ui/core';

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

    const loadData = useCallback(async () => {
        try
        {
            const conversationsURL = 'api/conversations';
            const conversationsResponse = await axios(conversationsURL);
            const conversationsData = conversationsResponse.data;
            
            setPeople(conversationsData);
        } catch(error) {
            console.log()
            alert(error.response.data.ExceptionMessage);
        }
    },[setPeople]);

    useEffect (() =>{
        loadData();
    },[loadData]);

    return(
      <Grid container direction={'column'} className={classes.bgLayer}>
        <Grid item>
            <h1 className={classes.heading}>Suggested</h1>
            <Paper className={classes.root}>
                {people && people.map(x => {
                    return (x && <ListPerson key={x?.Id} data={x}/>)
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