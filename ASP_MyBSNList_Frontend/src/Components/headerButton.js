import React, { useState } from 'react';
import Button from '@material-ui/core/Button';

const headerButton = (props) =>
{
    const [text,setText] = useState((props != undefined) ? props.text : "");

    return (
        <div className="headerButton">
            <Button variant="contained" color="primary">{text}</Button>
        </div>
    );
}

export default headerButton;