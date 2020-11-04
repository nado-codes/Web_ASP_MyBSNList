import React from 'react';
import {makeStyles} from '@material-ui/core';
import '../site.css';
import HeaderButton from './HeaderButton';

import Grid from '@material-ui/core/Grid';

import axios from 'axios';
//import Papa from 'papaparse'

const useStyles = makeStyles((theme) => ({
    root: {
        backgroundColor : '#242424',
        width : '100%',
        height: '75px',
        paddingLeft: '20px',
    },
    headerTitle: {
        color: '#FFF',
    },
    titleContainer: {
        marginRight: '50px', 
        textAlign: 'left', 
        width: 'auto',
    },
    navContainer : {
        flex : 0.75, 
        textAlign: 'left'
    },
}));

const Header = (props) =>
{
    const {theme} = props;
    const classes = useStyles(theme);

    return(
        <Grid className={classes.root} container alignItems={'center'}>
            <Grid item className={classes.titleContainer}>
                <h1 className={classes.headerTitle}>ASP My BSN List</h1>
            </Grid>

            <Grid item className={classes.navContainer}>
                <HeaderButton linkTo="/conversations" text="Conversations"/>
                <HeaderButton linkTo="/list" text="Lists"/>
            </Grid>
        </Grid>
    );
}


export default Header;