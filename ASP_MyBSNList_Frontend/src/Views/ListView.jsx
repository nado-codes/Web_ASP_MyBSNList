
import React, {useState, useEffect, useCallback} from 'react';

import {makeStyles} from '@material-ui/core';
import {Grid, Paper} from '@material-ui/core';

import ListTable from '../Components/ListTable';
import OptionButton from '../Components/OptionButton';
import axios from 'axios';

const useStyle = makeStyles((theme) => ({
    root: {
    },
    toolbarContainer: {
        marginTop: '10px',
        marginLeft: '50px',
        height: '50px',
    },
    tableContainer: {
        flex: 0.25,
    },
}));
const ListView = (props) => {
    const {theme} = props;
    const classes = useStyle(theme);

    const listTableColumns = [
        {Name: "SafeName", DisplayName: "Name", MaxWidth: '50px'},
        {Name: "MartialStatus", DisplayName: "Marital Status", MaxWidth: '25px'},
        {Name: "City", DisplayName: "City", MaxWidth: '225px'}
    ];
    const [listTableRows,setListTableRows] = useState([]);
    const [listTableColumnsPerRow,setListTableColumnsPerRow] = useState(3);
    const listTableRowsPerPage = 3;
    const [listSearch,setListSearch] = useState('a');

    const loadData = useCallback(async () => {
        const listUrl = `api/person?list=${listSearch}`;
        const listData = (await axios.get(encodeURI(listUrl))).data;

        setListTableRows(listData);

        handleResize(window.innerWidth,0);
    },[listSearch,setListTableRows]);

    useEffect(() => {
        loadData();
    },[loadData])

    const handleResizeClicked = (e) => {

        handleResize(e.target.innerWidth,0);
    }

    window.onresize = handleResizeClicked;

    const handleAListClicked = () => {
        setListSearch('a');
    }

    const handleBListClicked = () => {
        setListSearch('b');
    }

    const handleCListClicked = () => {
        setListSearch('c');
    }


    const handleResize = (newWidth, newHeight) => {
        
        const newColumnsPerRow = Math.round(newWidth / 250);
        setListTableColumnsPerRow(newColumnsPerRow);
    }
    
    

    return (
        
            <Grid container className={classes.root} direction='column'>
                <Paper>
                    <Grid item className={classes.toolbarContainer}>
                        <OptionButton click={handleAListClicked} text="A List"></OptionButton>
                        <OptionButton click={handleBListClicked} text="B List"></OptionButton>
                        <OptionButton click={handleCListClicked} text="C List"></OptionButton>
                        <span style={{fontWeight: 'bold', fontSize: '25px',}}>{listSearch.toUpperCase()+' List'}</span>
                    </Grid>
                    <Grid item className={classes.tableContainer}>
                        <ListTable
                            page={1}
                            columns={listTableColumns} 
                            rows={listTableRows} 
                            columnsPerRow={listTableColumnsPerRow} 
                            rowsPerPage={listTableRowsPerPage}
                        />
                    </Grid>
                </Paper>
            </Grid>
    )
}

export default ListView;