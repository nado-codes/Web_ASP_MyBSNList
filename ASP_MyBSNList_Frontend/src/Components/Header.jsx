import React from 'react';
import PropTypes from 'prop-types';
import '../site.css';
import HeaderButton from './headerButton';

import Grid from '@material-ui/core/Grid';

const Header = (props) =>
{
    return(
        <div className="header">

            <Grid container alignItems={'center'}>
                <Grid item style={{ flex : 0.25, textAlign: 'left', width: '20px'}}>
                    <h1>ASP My BSN List</h1>
                </Grid>

                <Grid item style={{ flex : 1, textAlign: 'left'}}>
                    <HeaderButton text="A List"/>
                    <HeaderButton text="B List"/>
                    <HeaderButton text="C List"/>
                </Grid>
            </Grid>
        </div>
    );
}

Header.PropTypes

export default Header;