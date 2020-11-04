import React from 'react';
import PropTypes from 'prop-types';
import {makeStyles, Button} from '@material-ui/core';
import {NavLink} from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
    HeaderButton: {
        backgroundColor: '#363636',
        color: '#FFF',
        marginRight: '5px',

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
            <Button variant="contained" className={classes.HeaderButton} component={props.component} onClick={ props.click ? () => {props.click(props.text)} : ()=>{}}>{props.text}</Button>
        </NavLink>
    );
}

HeaderButton.propTypes = {
    linkTo : PropTypes.string.isRequired,
}

export default HeaderButton;