import React ,{useState} from 'react';
import PropTypes from 'prop-types';
import '../site.css';
import HeaderButton from './headerButton';

import Grid from '@material-ui/core/Grid';
import {Dialog, DialogText, DialogContent, Fab} from '@material-ui/core/';

import axios from 'axios';
import Papa from 'papaparse'

const Header = (props) =>
{
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
        <div className="header">

            <Grid container alignItems={'center'}>
                <Grid item style={{ flex : 0.25, textAlign: 'left', width: '20px'}}>
                    <h1>ASP My BSN List</h1>
                </Grid>

                <Grid item style={{ flex : 0.75, textAlign: 'left'}}>
                    <HeaderButton click={clickHandler} text="List"/>

                    
                    <label htmlFor="upload-photo">
                        <input
                                style={{display: 'none'}}
                                id="upload-photo"
                                name="upload-photo"
                                type="file"
                                accept=".csv"
                                onChange={selectFileHandler}
                        />

                        <HeaderButton text="Upload List" component="span"/>
                        
                    </label>
                </Grid>
            </Grid>
        </div>
    );
}


export default Header;