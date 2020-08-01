import React, {useState,useEffect} from 'react';
import { makeStyles } from '@material-ui/core/styles';

import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import {Table,TableHead,TableFooter,TableBody,TableRow,TableCell} from '@material-ui/core';
import NewPersonForm from '../Components/NewPersonForm';

import axios from 'axios';

const useStyles = makeStyles((theme) => ({
    root: {
      flexGrow: 1,
    },
    paper: {
      padding: theme.spacing(2),
      textAlign: 'center',
      color: theme.palette.text.secondary,
    },
    grid: {
        width: '100%'
    }
  }));

const Page = (props) => {
    const classes = useStyles();

    const [pageName,setPageName] = useState(props.pageName);
    const [hello,setHello] = useState("");
    const [isNewPersonFormOpen,setIsNewPersonFormOpen] = useState(false);

    const columns = [
        {Id : 1, Name: "Status"},
        {Id : 2, Name: "Reason"},
        {Id : 3, Name: "Contacted"},
        {Id : 4, Name: "Process Stage"},
        {Id : 5, Name: "Last Message"},
        {Id : 6, Name: "Next Contact"},
        {Id : 7, Name: "Name"},
        {Id : 8, Name: "Primary"},
        {Id : 9, Name: "Secondary"},
        {Id : 10, Name: "Nationality"},
        {Id : 11, Name: "Current City"},
        {Id : 12, Name: "Occupation"},
        {Id : 13, Name: "Marital Status"},
        {Id : 14, Name: "Kids"},
        {Id : 15, Name: "Age Group"},
        {Id : 16, Name: "Met On"},
        {Id : 17, Name: "Remarks"},
    ]
    const sampleData = [
        {Id: 1, Name: "Item 1"},
        {Id: 2, Name: "Item 2"},
    ];

    useEffect (() =>{
        loadData();
        setPageName(props.pageName);
    });

    const loadData = async () => {
        const helloURL = 'api/helloWorld';
        const helloResponse = await axios(helloURL);
        const helloData = helloResponse.data;

        setHello(helloData.Name);
    }

    const handleAddNewClicked = () => {

    }

    return(
        
        <Grid container spacing={2} >
            
            <Grid item xs={11} >
                <h1>{pageName}</h1>
            </Grid>
            <Grid item xs={11}>
                <Paper className={classes.paper} style={{width:'100%'}}>
                    <h2>{hello}</h2>
                    <Table>
                        <TableHead>
                            <TableRow>
                                {columns.map((x) => (
                                    <TableCell>{x.Name}</TableCell>
                                ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {sampleData.map(x => (
                                <TableRow>
                                    <TableCell>{x.Id}</TableCell>
                                    <TableCell>{x.Name}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                        <TableFooter>
                            <div style={{paddingTop: "20px"}}>
                                <Button variant="contained" color="primary" onClick={handleAddNewClicked}>Add</Button>
                            </div>
                        </TableFooter>
                    </Table>
                </Paper>
            </Grid>

            <NewPersonForm
                open={isNewPersonFormOpen}
            />
        </Grid>
    );

}

export default Page;