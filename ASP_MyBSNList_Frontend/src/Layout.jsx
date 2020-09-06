import React from 'react';
import {Grid, makeStyles} from '@material-ui/core';
import {withStyles} from '@material-ui/core/styles';

const styles = makeStyles((theme) => ({
    bgLayer: {
        backgroundColor: '#121212',
    },
    childContent: {
        marginTop: theme.spacing(),
        flex: 1,
        flexDirection: 'column',
    },
  }));

const Layout = (props) => {
    const {classes} = props;

    return(
        <Grid className={classes.bgLayer}>{props.children}</Grid>
    );
}

export default withStyles(styles, {withTheme : true})(Layout);