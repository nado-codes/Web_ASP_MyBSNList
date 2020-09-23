import React ,{useState} from 'react';
import {makeStyles} from '@material-ui/core';
import PropTypes from 'prop-types';
import '../site.css';
import HeaderButton from './HeaderButton';

import Grid from '@material-ui/core/Grid';

import axios from 'axios';
import Papa from 'papaparse'

const useStyles = makeStyles((theme) => ({
    header: {
        backgroundColor : '#242424',
        width : '100%',
        paddingLeft: '20px',

        
    },

    title: {
        color: '#FFF',
    }
}));

const Header = (props) =>
{
    const {theme} = props;
    const classes = useStyles(theme);
    const [isShowFileUpload,setIsShowFileUpload] = useState(false);


    const clickHandler = (pageName) => {
        console.log("selected "+pageName);
        props.changePage(pageName);
    }

    const selectFileHandler = (event) => {
        const file = event.target.files[0];

        // Create an object of formData 
        Papa.parse(file, {
            complete: parseComplete,
            header: true
          });

        
    }

    const parseComplete = (result)  => {
        var data = result.data;

        console.log(data);

        axios({
            method: 'post',
            url: '/api/listUpload',
            responseType: 'json',
            data : data,
          })

        //axios.post("api/listUpload", data);
    }

    return(
        <Grid className={classes.header} container alignItems={'center'}>
            <Grid item style={{ marginRight: '50px', textAlign: 'left', width: 'auto'}}>
                <h1 className={classes.title}>ASP My BSN List</h1>
            </Grid>

            <Grid item style={{ flex : 0.75, textAlign: 'left'}}>
                <HeaderButton linkTo="/conversations" text="Conversations"/>
                
                {/*<label htmlFor="upload-photo">
                    <input
                            style={{display: 'none'}}
                            id="upload-photo"
                            name="upload-photo"
                            type="file"
                            accept=".csv"
                            onChange={selectFileHandler}
                    />
                    <HeaderButton text="Upload List" component="span"/>
                    
                </label>*/}
            </Grid>
        </Grid>
    );
}


export default Header;