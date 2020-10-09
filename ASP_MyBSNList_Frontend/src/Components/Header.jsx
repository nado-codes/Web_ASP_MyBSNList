import React ,{useState} from 'react';
import {makeStyles} from '@material-ui/core';
import {TextField, Paper} from '@material-ui/core';
import '../site.css';
import HeaderButton from './HeaderButton';
import {Autocomplete} from '@material-ui/lab';

import Grid from '@material-ui/core/Grid';

import axios from 'axios';
//import Papa from 'papaparse'

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
    const [searchedUsers,setSearchedUsers] = useState([]);
    //const [isShowFileUpload,setIsShowFileUpload] = useState(false);


    /*const clickHandler = (pageName) => {
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
    }*/

    const handleSearchQueryChanged = async (event) => {

        try
        {
            const query = event.target.value;

            

            const personsUrl = `api/person/?q=${query}`;

            console.log(axios.baseUrl);

            const personsData = (await axios.get(encodeURI(personsUrl))).data;

            setSearchedUsers(personsData);
        }
        catch (error) {
            alert(error.Response ? error.response.data.ExceptionMessage : error);
        }
    }

    const handleLoadUser = (event,value) => {

        const personId = value.Id;
        window.location = `person/${personId}`;
        console.log(personId);
    }

    return(
        <Grid className={classes.header} container alignItems={'center'}>
            <Grid item style={{ marginRight: '50px', textAlign: 'left', width: 'auto'}}>
                <h1 className={classes.title}>ASP My BSN List</h1>
            </Grid>

            <Grid item style={{ flex : 0.75, textAlign: 'left'}}>
                <HeaderButton linkTo="/conversations" text="Conversations"/>
                <HeaderButton linkTo="/list" text="Lists"/>

                {/*<Paper>
                <Autocomplete
                    id="usersSearch"
                    options={searchedUsers}
                    getOptionLabel={x => x.Name}
                    style={{marginLeft : '10px'}}
                    onChange={handleLoadUser}
                    onInputChange={handleSearchQueryChanged}
                    renderInput={params => <TextField {...params}/>}
                />
                </Paper>*/}
            </Grid>
        </Grid>
    );
}


export default Header;