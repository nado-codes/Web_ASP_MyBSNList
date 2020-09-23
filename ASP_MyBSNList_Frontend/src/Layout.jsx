import React from 'react';
import {Grid, makeStyles} from '@material-ui/core';
import {withStyles} from '@material-ui/core/styles';

import Header from './Components/Header';

const useStyles = makeStyles((theme) => ({
    bgLayer: {
        backgroundColor: '#000000',
        height: '100%',
    },
  }));

const Layout = (props) => {
    const {theme} = props;
    const classes = useStyles(theme);
    const {backgroundColor} = classes.bgLayer;

    console.log(backgroundColor);
    document.body.style.backgroundColor = backgroundColor;

    return(
        <Grid container direction={'column'} className={classes.bgLayer}>
            <Header/>
            {props.children}
        </Grid>
    );
}

export default withStyles(useStyles, {withTheme : true})(Layout);