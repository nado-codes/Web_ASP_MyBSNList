import React from 'react';
import PropTypes from 'prop-types';
import '../site.css';
import HeaderButton from './headerButton';
import IconButton from '@material-ui/core/IconButton';

import Grid from '@material-ui/core/Grid';
import SettingsIcon from '@material-ui/icons/Settings';

const Header = (props) =>
{
    const clickHandler = (pageName) => {
        console.log("selected "+pageName);
        props.changePage(pageName);
    }

    const selectSetting = () => {

    }
    const closeSettings = () => {

    }

    return(
        <div className="header">

            <Grid container alignItems={'center'}>
                <Grid item style={{ flex : 0.25, textAlign: 'left', width: '20px'}}>
                    <h1>ASP My BSN List</h1>
                </Grid>

                <Grid item style={{ flex : 0.75, textAlign: 'left'}}>
                    <HeaderButton click={clickHandler} text="List"/>
                </Grid>

                {/*<Grid item style={{ flex : 0.25, textAlign: 'right', width: '5px'}}>
                    <IconButton color="primary" aria-label="upload picture" component="span">
                        <SettingsIcon/>
                    </IconButton>
                </Grid>*/}
            </Grid>
        </div>
    );
}


export default Header;