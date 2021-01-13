import React, {useState, useEffect, useCallback} from 'react';
import {useParams} from 'react-router-dom';
import {makeStyles,
    Box,
    Button,
    Paper,
    Typography,
    Grid,
    AppBar,
    Tab,
    Tabs,
    Table,
    TableBody,
    TableRow,
    TableCell} from '@material-ui/core';

import EditField from '../Components/EditField';

import AccountBoxIcon from '@material-ui/icons/AccountBox';
import ChatIcon from '@material-ui/icons/Chat';
import ForumIcon from '@material-ui/icons/Forum';
import NotesIcon from '@material-ui/icons/Notes';
import DeleteIcon from '@material-ui/icons/Delete';

import axios from 'axios';

const useStyles = makeStyles((theme) => ({
    root: {
        margin: '20px',
        width: '100%',
    },
    profileSection : {
        marginTop: '10px',
    },
    profileTabs: {
        background: '#000000',
        color: '#FFFFFF',
    },
    sectionTitle: {
        fontWeight: 'bold',
    },
    sectionTitleB: {
        fontWeight: 'bold',
        marginBottom: '10px',
    },
    leftPanelRoot: {
        flex: 0.33,
        textAlign: 'center',
    },
    leftPanelDetails: {
        textAlign: 'left',
    },
    rightPanelRoot: {
        flex: 0.66,
    },
    rightPanelTable: {
        width: '500px',
        height: '300px',
        paddingRight: '400px',
    },
    rightPanelTableRCell: {
        width: '50px',
    },
    icon:
    {
        fontSize: '300px',
    },
    buttonIcon:
    {
        marginRight: '5px',
    },
    buttonIconRed:
    {
        marginRight: '5px',
        color: '#FF0000',
    },
    textSecondary: {
        color: '#000000',
    },
    greyRounded: {
        background: '#000000',
        borderRadius: '8px',
        width: '75px',
        textAlign: 'center',

        '& Typography' : {
            color: '#FFF',
        },
    },
    greyRoundedText: {
        color: '#FFFFFF',
    },
}));

function TabPanel(props) {
    const { children, value, index, ...other } = props;
  
    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`simple-tabpanel-${index}`}
        aria-labelledby={`simple-tab-${index}`}
        {...other}
      >
        {value === index && (
          <Box p={3}>
            <Typography>{children}</Typography>
          </Box>
        )}
      </div>
    );
  }

const PersonView = (props) => {
    const {theme} = props;
    const classes = useStyles(theme);
    const {id} = useParams();
    const safe = false;

    const [personData,setPersonData] = useState({});

    const defaultColumns = {
        EMPTYORNULL: {
            DisplayName: "Unknown "
        },
        NA: {
            DisplayName: "N/A"
        },
        OPTIONS: {
            Confirm: [{Id: 0, Name: "Yes"}, {Id: 1, Name: "No"}]
        }
    }

    const personColumns = {
        Name: {
            Id: "Name", DisplayName: "Name"
        },
        PrimaryCommunication: {
            Id: "PrimaryCommunication", DisplayName: "Primary Communication"
        },
        SecondaryCommunication: {
            Id: "SecondaryCommunication", DisplayName: "Secondary Communication"
        },
        Nationality: {
            Id: "Nationality", DisplayName: "Nationality"
        },
        Country: {
            Id: "Country", DisplayName: "Country"
        },
        City: {
            Id: "City", DisplayName: "City"
        },
        Occupation: {
            Id: "Occupation", DisplayName: "Occupation"
        },
        Industry: {
            Id: "Industry", DisplayName: "Industry"
        },
        MaritalStatus: {
            Id: "MartialStatus", DisplayName: "Marital Status"
        },
        AgeGroup: {
            Id: "AgeGroup", DisplayName: "Age Group"
        },
        HasKids: {
            Id: "HasKids", DisplayName: "Kids", TRUE: "Yes", FALSE: "None"
        },
        Remarks: {
            Id: "Remarks", DisplayName: "Remarks"
        },
        LastContact: {
            Id: "LastContact", DisplayName: "Last Contact"
        },
        List: {
            Id: "List", DisplayName: " List"
        },
        Gender: {
            Id: "Gender", DisplayName: "Gender", Options: [{Id: 0, Name: "Male"}, {Id: 1, Name: "Female"}]
        },
        Person: {
            Id: "Person", DisplayName: "Person"
        },
    }

    const Options = {
        GENDER: [
            {Id: 0, Name: "Male"},
            {Id: 1, Name: "Female"}
        ]
    }

    const loadPersonData = useCallback(async () => {
        const personURL = 'api/person/'+id;
        const personData = (await axios({
            method:'GET',
            url: personURL,
            baseURL: '/',
        })).data;

        console.log(personData);

        setPersonData(personData);
    },[id]);

    useEffect(() => {
        loadPersonData();
    },[loadPersonData]);

    const [value, setValue] = useState(0);

    const hangleChangeTab = (e, newValue) => {
        setValue(newValue);
    };

    const handleUpdateValue = async (name,value) => {

        console.log("updating "+name);
        const newPersonData = {...personData, [name]: value};

        console.log(newPersonData);

        const personURL = 'api/person/';
        const personResponse = (await axios({
            method:'PUT',
            data: newPersonData,
            url: personURL,
            baseURL: '/',
        })).data;

        setPersonData(newPersonData);
    }

    return(
        <Paper className={classes.root}>
            <Grid container direction={'row'} className={classes.root}>
                <Grid container direction={'column'} className={classes.leftPanelRoot}>
                    <Grid item>
                        <AccountBoxIcon className={classes.icon}/>
                    </Grid>
                    <Grid item className={classes.leftPanelDetails}> {/*LEFT DETAILS*/}
                    <Typography variant="h5" className={classes.sectionTitle}>Details</Typography>
                        <Table>
                            <TableBody>
                                <TableRow>
                                    <TableCell>
                                        <Grid container direction={'column'}>
                                            <Grid item> {/*COUNTRY*/}
                                                <EditField 
                                                    variant="h6"
                                                    style={{marginBottom: '10px'}}
                                                    className={classes.sectionTitleB} 
                                                    name={personColumns.Country.Id}
                                                    onValueUpdated={handleUpdateValue}
                                                    value={personData?.[personColumns.Country.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName+personColumns.Country.DisplayName}
                                                    dataUrl={"api/countries"}
                                                    defaultColumns={defaultColumns}
                                                />
                                            </Grid>
                                            <Grid item> {/*CITY*/}
                                                <EditField
                                                        name={personColumns.City.Id}
                                                        onValueUpdated={handleUpdateValue}
                                                        value={personData?.[personColumns.City.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName+personColumns.City.DisplayName}
                                                        dataUrl={"api/cities"}
                                                        defaultColumns={defaultColumns}
                                                />
                                            </Grid>
                                        </Grid>

                                    </TableCell>
                                </TableRow>

                                <TableRow>
                                    <TableCell>
                                        <Grid container direction={'column'}>
                                            <Grid item> {/*INDUSTRY*/}
                                                <EditField
                                                    variant="h6"
                                                    style={{marginBottom: '10px'}}
                                                    className={classes.sectionTitleB} 
                                                    name={personColumns.Industry.Id}
                                                    onValueUpdated={handleUpdateValue}
                                                    value={personData?.[personColumns.Industry.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName+personColumns.Industry.DisplayName}
                                                    dataUrl={"api/industries"}
                                                    defaultColumns={defaultColumns}
                                                />
                                            </Grid>
                                            <Grid item> {/*OCCUPATION*/}
                                                <EditField
                                                        name={personColumns.Occupation.Id}
                                                        onValueUpdated={handleUpdateValue}
                                                        value={personData?.[personColumns.Occupation.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName+personColumns.Occupation.DisplayName}
                                                        dataUrl={"api/occupations"}
                                                        defaultColumns={defaultColumns}
                                                />
                                            </Grid>
                                        </Grid>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </Grid>
                </Grid>
                <Grid container direction={'column'} className={classes.rightPanelRoot}>
                    <Grid item>
                        <Grid item>                      {/*NAME*/}
                            <Typography variant="h4" className={classes.sectionTitle}>{(safe ? personData?.SafeName : personData?.Name) ?? defaultColumns.EMPTYORNULL.DisplayName+personColumns.Person.DisplayName}</Typography>
                        </Grid>
                        <Grid container direction="row"> {/*LIST*/}
                            <Box className={classes.greyRounded}><Typography className={classes.greyRoundedText} variant="h6">{(personData?.[personColumns.List.Id] ?? defaultColumns.NA.DisplayName) + personColumns.List.DisplayName}</Typography></Box> 
                            <Button style={{marginLeft: '140px'}}><ChatIcon className={classes.buttonIcon} /> Start Conversation</Button>
                            <Button style={{marginLeft: '5px'}}><DeleteIcon className={classes.buttonIconRed} /> <span className={classes.buttonIconRed}>Delete</span></Button>
                        </Grid>
                    </Grid>
                    <Grid item>
                        {/*Possibly going to put a status bar here - design still required*/}
                    </Grid>
                    <Grid container direction="column" className={classes.profileSection}>
                        <Table className={classes.rightPanelTable} size="small">
                            <TableBody>
                            <TableRow>{/*GENDER*/}
                                <TableCell>{personColumns.Gender.DisplayName}</TableCell>
                                <TableCell>
                                    <EditField 
                                        name={personColumns.Gender.Id}
                                        onValueUpdated={handleUpdateValue}
                                        value={personColumns.Gender.Options[personData?.[personColumns.Gender.Id]]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName}
                                        options={personColumns.Gender.Options}
                                        useOptionId
                                        defaultColumns={defaultColumns}
                                    />
                                </TableCell>
                            </TableRow>
                            <TableRow>{/*NATIONALITY*/}
                                <TableCell>{personColumns.Nationality.DisplayName}</TableCell>
                                <TableCell>
                                    <EditField 
                                        name={personColumns.Nationality.Id}
                                        onValueUpdated={handleUpdateValue}
                                        value={personData?.[personColumns.Nationality.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName}
                                        dataUrl={"api/countries"}
                                        defaultColumns={defaultColumns}
                                    />
                                </TableCell>
                            </TableRow>
                            <TableRow>{/*MARITAL STATUS*/}
                                <TableCell>{personColumns.MaritalStatus.DisplayName}</TableCell>
                                <TableCell>
                                    <EditField 
                                        name={personColumns.MaritalStatus.Id}
                                        onValueUpdated={handleUpdateValue}
                                        value={personData?.[personColumns.MaritalStatus.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName}
                                        dataUrl={"api/maritalstatuses"}
                                        defaultColumns={defaultColumns}
                                    />
                                </TableCell>
                            </TableRow>
                            <TableRow>{/*AGE GROUP*/}
                                <TableCell>{personColumns.AgeGroup.DisplayName}</TableCell>
                                <TableCell>
                                    <EditField 
                                        name={personColumns.AgeGroup.Id}
                                        onValueUpdated={handleUpdateValue}
                                        value={personData?.[personColumns.AgeGroup.Id]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName}
                                        dataUrl={"api/agegroups"}
                                        defaultColumns={defaultColumns}
                                    />
                                </TableCell>
                            </TableRow>
                            <TableRow>{/*HAS KIDS*/}
                                <TableCell>{personColumns.HasKids.DisplayName}</TableCell>
                                <TableCell>
                                    <EditField 
                                        name={personColumns.HasKids.Id}
                                        onValueUpdated={handleUpdateValue}
                                        value={defaultColumns.OPTIONS.Confirm[personData?.[personColumns.HasKids.Id] ? 1 : 0]?.Name ?? defaultColumns.EMPTYORNULL.DisplayName}
                                        options={defaultColumns.OPTIONS.Confirm}
                                        useOptionId
                                        defaultColumns={defaultColumns}
                                    />
                                </TableCell>
                            </TableRow>
                            <TableRow>{/*LAST CONTACT*/}
                                <TableCell>{personColumns.LastContact.DisplayName}</TableCell>
                                <TableCell>
                                    <Typography style={{fontSize: '15px'}}>{personData?.[personColumns.LastContact.Id] ?? defaultColumns.EMPTYORNULL.DisplayName}</Typography>
                                </TableCell>
                             </TableRow>
                            </TableBody>
                        </Table>
                        <Grid item className={classes.profileSection}>
                            
                        </Grid>
                    </Grid>
                    <Grid item className={classes.profileSection} style={{marginTop: '10px'}}>
                        <AppBar position="static" className={classes.profileTabs}>
                          <Tabs value={value} onChange={hangleChangeTab} aria-label="simple tabs example">
                            <Tab label={<div><NotesIcon style={{verticalAlign: 'middle'}} /> Remarks </div>}/>
                            <Tab label={<div><ForumIcon style={{verticalAlign: 'middle'}} /> Messages </div>}/>
                          </Tabs>
                        </AppBar>
                        <TabPanel value={value} index={0}>
                            {/*Details*/}
                        </TabPanel>
                        <TabPanel value={value} index={1}>
                            {/*Remarks*/}
                        </TabPanel>
                        <TabPanel value={value} index={2}>
                            {/*Messages*/}
                        </TabPanel>
                    </Grid>
                </Grid>     
            </Grid>
        </Paper>
    );
}

export default PersonView;