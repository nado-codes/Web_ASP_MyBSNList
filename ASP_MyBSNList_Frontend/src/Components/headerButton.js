import React, { useState } from 'react';
import Button from '@material-ui/core/Button';

const headerButton = (props) =>
{
    return (
        <div className="headerButton">
            <Button variant="contained" color="primary" component={props.component} onClick={ props.click ? () => {props.click(props.text)} : ()=>{}}>{props.text}</Button>
        </div>
    );
}

export default headerButton;