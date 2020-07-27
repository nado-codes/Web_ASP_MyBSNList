import React from 'react';
import PropTypes from 'prop-types';
import '../site.css';
import HeaderButton from './headerButton';

import Grid from '@material-ui/core/Grid';

const Header = (props) =>
{
    const clickHandler = (pageName) => {
        console.log("selected "+pageName);
        props.changePage(pageName);
    }

    return(
        <div className="header">

            <Grid container alignItems={'center'}>
                <Grid item style={{ flex : 0.25, textAlign: 'left', width: '20px'}}>
                    <h1>ASP My BSN List</h1>
                </Grid>

                <Grid item style={{ flex : 1, textAlign: 'left'}}>
                    <HeaderButton click={clickHandler} text="A List"/>
                    <HeaderButton click={clickHandler} text="B List"/>
                    <HeaderButton click={clickHandler} text="C List"/>
                </Grid>
            </Grid>
        </div>
    );
}


export default Header;