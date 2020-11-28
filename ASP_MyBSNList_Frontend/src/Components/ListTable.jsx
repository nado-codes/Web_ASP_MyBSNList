import React, {useState, useEffect, useCallback} from 'react';
import {makeStyles} from '@material-ui/core';
import { Grid, Paper} from '@material-ui/core';
import {Pagination} from '@material-ui/lab';

import TableForm, {
    DialogMode,
    TableFormField, 
    TableFormFieldType as FieldType } from '../Components/TableForm';

import OptionButton from '../Components/OptionButton';
import CardPerson from '../Components/CardPerson';
import axios from 'axios';

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

    const [columnsPerRow,setColumnsPerRow] = useState(props.columnsPerRow);
    const [rowsPerPage,setRowsPerPage] = useState([props.rowsPerPage]);
    
    const [rows,setRows] = useState([]);
    const [numPages,setNumPages] = useState(0);
    const [page,setPage] = useState(props.page);
    const [sortedPages,setSortedPages] = useState([]);
    //const [lastAddedPerson,setLastAddedPerson] = useState(undefined);

    // ADD PERSON FORM
    const [formIsOpen,setFormIsOpen] = useState(false);
    const [formTitle,setFormTitle] = useState(undefined);
    const [formBody,setFormBody] = useState(undefined);
    const [formHandleAffirm,setFormHandleAffirm] = useState(undefined);
    const formHandleDeny = undefined; //[formHandleDeny,setFormHandleDeny] = useState(undefined);
    const [formMode,setFormMode] = useState(DialogMode.PROMPT);
    const [formFields,setFormFields] = useState([]);
    const [formEditState,setFormEditState] = useState({});
    const [formError,setFormError] = useState(undefined);

    // CONSTANTS

    const pageStrings = {
        ADD_NEW: "Add New"
    }

    const dialogStrings = {
        DIALOG_PERSON_DESC: "Enter some information about this person",
        ADD_PERSON: "Add Person",
        EDIT_PERSON: "Edit Person",
        DELETE_PERSON: "Delete Person",
        DELETE_PERSON_DESC: "This cannot be undone. Continue?",
    }

    const lists = [
        {Id: 1, Name: 'A'},
        {Id: 2, Name: 'B'},
        {Id: 3, Name: 'C'}
    ];

    const dialogFields = {
        ADDEDIT: [
            TableFormField({id: 'Name', label: 'Name'}),
            TableFormField({
                id: 'List', 
                label: 'List', 
                type: FieldType.SELECT, 
                items: lists
            })
        ]
    }

    const sortData = useCallback(() => {

        const newSortedPages = [];

        const numPages = Math.round(rows?.length / (rowsPerPage*columnsPerRow));

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
                    
                    newRow[column] = rows[index];
                }
            
                newPage[row] = newRow;
            }

            newSortedPages[page] = newPage;
        }

        setNumPages(numPages);
        setSortedPages(newSortedPages);
    },[rows,columnsPerRow,rowsPerPage]);

    useEffect(() => {

        
        setRows(props.rows);
        //setFormHandleDeny(() => {});
        

        /*if(lastAddedPerson)
        {
            setPage(numPages);
            setLastAddedPerson(undefined);
        }*/
        
    },[props.rows]);

    useEffect(() => {
        sortData();

    },[rows,sortData])

    useEffect(() => {
        setColumnsPerRow(props.columnsPerRow);
        setRowsPerPage(props.rowsPerPage);
    },[props.columnsPerRow,props.rowsPerPage])

    window.onerror = (err) => {
        handleFormError(err);
    }

    const handleCloseForm = () => {
        setFormIsOpen(false);
    }
    const handleFormAffirmClicked = (e,editState) => {
        clearFormError();

        try
        {
            formHandleAffirm(e,editState);
            handleCloseForm();
        }
        catch (err)
        {
            handleFormError(err);
            console.log("error occured");
        }
    }   

    const handleFormDenyClicked = () => {
        clearFormError();

        try
        {
            formHandleDeny();
            handleCloseForm();
        }
        catch (err)
        {
            handleFormError(err);
        }
    }

    const handleFormError = (error) => {
        const message = error.response?.data.ExceptionMessage ?? "Unknown Error";

        setFormError(error ? message : undefined);
    }

    const clearFormError = () => {
        setFormError(undefined);
    }

    const handleChangePageClicked = (e,page) => {
        setPage(page);
    }

    const handleAddPersonClicked = () => {
        setFormTitle(dialogStrings.ADD_PERSON);
        setFormBody(dialogStrings.DIALOG_PERSON_DESC);
        setFormHandleAffirm(() => handleAddPerson);
        setFormMode(DialogMode.INPUT);
        setFormFields(dialogFields.ADDEDIT);
        setFormEditState({
            Name: '',
            List: 'C'
        });
        setFormIsOpen(true);
    }

    const handleDeletePersonClicked = (id) => {
        setFormTitle(dialogStrings.DELETE_PERSON);
        setFormBody(dialogStrings.DELETE_PERSON_DESC);
        setFormHandleAffirm(() => handleDeletePerson);
        setFormMode(DialogMode.CONFIRM);
        setFormFields([]);
        setFormEditState({ Id: id });
        setFormIsOpen(true);
    }

    const handleAddPerson = async (e,editState) => {
        
        try
        {
            const personsUrl = `api/person`;
            const personsData = (await axios.post(personsUrl,editState)).data;

            console.log("add person");
            console.log(editState);

            window.location = `/person/${personsData.Id}`;

            //const newRows = [...rows,personsData];
            //setRows(newRows);
        } catch (err) {
            handleFormError(err);
        }
    }

    const handleDeletePerson = async (e,editState) => {

        try
        {
        console.log("delete person /w id "+editState.Id);

        const personsUrl = `api/person`;
        const personsData = (await axios({method: 'delete', url: personsUrl,data: editState})).data;

        if(personsData !== 1)
            console.error("Error deleting person - expected one row to be updated, got 0");

        const newRows = rows.filter(x => x.Id !== editState.Id);
        setRows(newRows);
        }
        catch (err) {
            console.error(err);
        }
    }

    return(
        <Paper>
            <Grid container className={classes.root}>
                <Grid container direction={'row'} className={classes.grid}>
                    {sortedPages[page-1]?.map(x => {
                        const rowIndex = sortedPages[page-1]?.indexOf(x);

                        return (<Grid container key={rowIndex} className={classes.row}>
                            {x.map(y => {
                                const columnIndex = rowIndex+""+x.indexOf(y);

                                return (<Grid item key={columnIndex} className={classes.column}>
                                    {y && 
                                    <CardPerson 
                                        data={y} 
                                        indexNum={rows.indexOf(y)}
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
                error={formError}
                fieldsInfo={formFields}
                editState={formEditState}
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
    onPersonAdded: () => {},
}

export default ListTable;