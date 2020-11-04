import React, {useState, useEffect, useCallback} from 'react';
import {makeStyles} from '@material-ui/core';
import { Grid, Paper} from '@material-ui/core';
import {Pagination} from '@material-ui/lab';

import {DialogMode, TableForm} from '../Components/TableForm';
import OptionButton from '../Components/OptionButton';
import CardPerson from '../Components/CardPerson';

const styles = {
    toolbarButton: {
        height: '25px',
        width: '125px',
        background: 'red',
    }
}
const useStyle = makeStyles((theme) => ({
    root: {
        width: '100%',
    },
    noWrap: {
        overflow: 'ellipsis',
        textOverflow: 'ellipsis',
    },
    grid: {
        padding: '50px',
        paddingTop: '10px',
        minHeight: '500px',
        maxHeight: '500px',
        
    },
    column: {
        padding: '10px',
        marginRight: '-5px',
    },
    row: {
        marginTop: '-7.5px',
    },
    tableFooter: {
        width: '100%',
    },
    toolbarContainer : {
        marginLeft: '10px',
    },
}));

const ListTable = (props) => {

    const {theme} = props;
    const classes = useStyle(theme);
    const {data} = props;

    const [columnsPerRow,setColumnsPerRow] = useState(props.columnsPerRow);
    const [rowsPerPage,setRowsPerPage] = useState(props.rowsPerPage);
    
    const [numPages,setNumPages] = useState(0);
    const [page,setPage] = useState(1);
    const [sortedPages,setSortedPages] = useState([]);

    // ADD PERSON FORM
    const [formIsOpen,setFormIsOpen] = useState(false);
    const [formTitle,setFormTitle] = useState(undefined);
    const [formBody,setFormBody] = useState(undefined);
    const [formHandleAffirm,setFormHandleAffirm] = useState(undefined);
    const [formHandleDeny,setFormHandleDeny] = useState(undefined);
    const [formMode,setFormMode] = useState()

    // CONSTANTS

    const pageStrings = {
        ADD_NEW: "Add New",
        ADD_PERSON: "Add Person",
        DIALOG_PERSON_DESC: "Enter some information about this person",
    }

    const dialogStrings = {
        DIALOG_PERSON_DESC: "Enter some information about this person",
        ADD_PERSON: "Add Person",
        EDIT_PERSON: "Edit Person",
        DELETE_PERSON: "Delete Person",
        DELETE_PERSON_DESC: "This cannot be undone. Continue?",
    }

    const sortData = useCallback(() => {

        const newSortedPages = [];

        const numPages = Math.round(data?.length / (rowsPerPage*columnsPerRow));

        for(var page = 0; page < numPages; page++)
        {
            const newPage = [];
            const pageStart = page*columnsPerRow*rowsPerPage;

            for(var row = 0; row < rowsPerPage; row++)
            {
                const newRow = [];
                const rowStart = columnsPerRow*row;
            
                for(var column = 0; column < columnsPerRow; column++)
                {
                    const index = (rowStart+pageStart+column);
                    
                    newRow[column] = data[index];
                }
            
                newPage[row] = newRow;
            }

            newSortedPages[page] = newPage;
        }

        setNumPages(numPages);
        setSortedPages(newSortedPages);
    },[data,columnsPerRow,rowsPerPage]);

    useEffect(() => {
        sortData();

        setFormHandleDeny(() => {});
        setColumnsPerRow(props.columnsPerRow);
        setRowsPerPage(props.rowsPerPage);
        
    },[props.columnsPerRow,props.rowsPerPage, sortData]);

    const handleCloseForm = () => {
        setFormIsOpen(false);
    }
    const handleFormAffirmClicked = () => {
        try
        {
            formHandleAffirm();
            handleCloseForm();
        }
        catch
        {

        }
    }   

    const handleFormDenyClicked = () => {
        try
        {
            formHandleDeny();
            handleCloseForm();
        }
        catch
        {
            
        }
    }

    const handleChangePageClicked = (e,page) => {
        setPage(page);
    }

    const handleAddPersonClicked = () => {
        setFormTitle(dialogStrings.ADD_PERSON);
        setFormBody(pageStrings.DIALOG_PERSON_DESC);
        setFormHandleAffirm(() => handleAddPerson);
        setFormIsOpen(true);
    }

    const handleDeletePersonClicked = () => {
        setFormTitle(dialogStrings.DELETE_PERSON);
        setFormBody(pageStrings.DELETE_PERSON_DESC);
        setFormHandleAffirm(() => handleDeletePerson);
        setFormIsOpen(true);
    }

    const handleAddPerson = () => {
        console.log("add person");
    }

    const handleDeletePerson = () => {
        console.log("add person");
    }

    return(
        <Paper>
            <Grid container className={classes.root}>
                <Grid container direction={'row'} className={classes.grid}>
                    {sortedPages[page-1]?.map(x => {
                        return (<Grid container key={sortedPages[page-1]?.indexOf(x)} className={classes.row}>
                            {x.map(y => {
                                return (<Grid item key={x.indexOf(y)} className={classes.column}>
                                    {y && 
                                    <CardPerson 
                                        data={y} 
                                        indexNum={data.indexOf(y)}
                                        onDeleteClicked={handleDeletePersonClicked}
                                    />}
                                </Grid>);
                            })}
                        </Grid>);
                    })}
                </Grid>
                <Grid container direction='row'>
                    <Grid item>
                        <Pagination count={numPages} onChange={handleChangePageClicked}/>
                    </Grid>
                    <Grid item className={classes.toolbarContainer}>
                        <OptionButton click={handleAddPersonClicked} text={pageStrings.ADD_NEW} styles={styles}/>
                    </Grid>
              </Grid>
            </Grid>

            <TableForm
                isOpen={formIsOpen}
                title={formTitle}
                body={formBody}
                mode={formMode}
                handleAffirm={handleFormAffirmClicked}
                handleDeny={handleFormDenyClicked}
                onClose={handleCloseForm}
            />
        </Paper>
    )
}

ListTable.defaultProps = {
    handleFormAffirm : () => {},
    handleFormDeny: () => {},
}

export default ListTable;