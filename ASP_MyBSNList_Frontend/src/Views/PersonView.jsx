import React, {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';
import {makeStyles,Paper,Typography,Grid} from '@material-ui/core';

import AccountBoxIcon from '@material-ui/icons/AccountBox';

import axios from 'axios';

const useStyles = makeStyles((theme) => ({
    root: {
        margin: '20px',
        width: '100%',
        height: '100%',
        background: 'yellow',
    },
    leftPanelRoot: {
        flex: 0.5,
        background: 'red',
        textAlign: 'center',
    },
    rightPanelRoot: {
        flex: 0.5,
        background: 'green',
    },
    icon:
    {
        fontSize: '200px',
    },
    textSecondary: {
        color: 'Aqua',
    },
}));

const PersonView = (props) => {
    const {theme} = props;
    const classes = useStyles(theme);
    const {id} = useParams();

    const [personData,setPersonData] = useState(undefined);

    

    useEffect(() => {
        loadPersonData();
    },[]);

    const loadPersonData = async () => {
        const personURL = 'api/person/'+id;
        const personData = (await axios({
            method:'GET',
            url: personURL,
            baseURL: '/',
        })).data;

        console.log(personData);

        setPersonData(personData);
    }

    return(
        <Paper className={classes.root}>
            <Grid container direction={'row'} className={classes.root}>
                <Grid item className={classes.leftPanelRoot}>
                    <AccountBoxIcon className={classes.icon}/>
                </Grid>
                <Grid item className={classes.rightPanelRoot}>
                <Typography variant="h4">{personData?.Name}</Typography>
                <Typography className={classes.textSecondary} variant="h6">{personData?.List} List</Typography>   
                </Grid>     
            </Grid>
        </Paper>
    );
}

export default PersonView;