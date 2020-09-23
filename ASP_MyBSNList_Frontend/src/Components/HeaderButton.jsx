import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {makeStyles} from '@material-ui/core';
import {Grid,Button} from '@material-ui/core';
import {NavLink} from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
    HeaderButton: {
        backgroundColor: '#363636',
        color: '#FFF',

        '&:hover': {
            backgroundColor: '#484848',
        },
    },
    HeaderButtonLink: {
        textDecoration : 'none',
    },
}));

const HeaderButton = (props) =>
{
    const {theme} = props;
    const classes = useStyles(theme);

    return (
        <NavLink to={props.linkTo ?? "?"} className={classes.HeaderButtonLink}>
            <Grid container>
                <Button variant="contained" className={classes.HeaderButton} component={props.component} onClick={ props.click ? () => {props.click(props.text)} : ()=>{}}>{props.text}</Button>
            </Grid>
        </NavLink>
    );
}

HeaderButton.propTypes = {
    linkTo : PropTypes.string.isRequired,
}

export default HeaderButton;