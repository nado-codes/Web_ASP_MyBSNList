import React from 'react';
import {makeStyles,Button} from '@material-ui/core';

const useStyles = makeStyles((theme,styles) => ({
    HeaderButton: {
        backgroundColor: '#363636',
        color: '#FFF',
        marginRight: '5px',
        height: '30px',
        width: '110px',

        '&:hover': {
            backgroundColor: '#484848',
        },
    },
    HeaderButtonLink: {
        textDecoration : 'none',
    }
}));

const OptionButton = (props) =>
{
    const {theme} = props;
    const classes = useStyles(theme,props.styles);

    return (
        <Button variant="contained" className={classes.HeaderButton} component={props.component} onClick={ props.click ? () => {props.click(props.text)} : ()=>{}}>{props.text}</Button>
    );
}

export default OptionButton;