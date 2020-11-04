import React from 'react';
import {Grid, makeStyles} from '@material-ui/core';

import Header from './Components/Header';

const useStyles = makeStyles((theme) => ({
    bgLayer: {
        backgroundColor: '#000000',
        height: window.innerHeight,
        width: '100%',
    },
  }));

const Layout = (props) => {
    const {theme} = props;
    const classes = useStyles(theme);

    return(
        <Grid container className={classes.bgLayer}>
            <Header/>
            {props.children}
        </Grid>
    );
}

export default Layout;