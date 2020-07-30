import React, {useState,useEffect} from 'react';
import { makeStyles } from '@material-ui/core/styles';

import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableRow from '@material-ui/core/TableRow';
import TableCell from '@material-ui/core/TableCell';

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

    return(
        
        <Grid container spacing={2} >
            
                <Grid item xs={11} >
                    <h1>{pageName}</h1>
                    <Paper className={classes.paper} style={{width:'100%'}}>
                        <h2>{hello}</h2>
                        <Table>
                            {sampleData.map(x => (
                                <TableRow>
                                    <TableCell>{x.Id}</TableCell>
                                    <TableCell>{x.Name}</TableCell>
                                </TableRow>
                            ))}
                        </Table>
                    </Paper>
                </Grid>
            
        </Grid>
    );

}

export default Page;