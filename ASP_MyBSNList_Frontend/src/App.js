import React, {useState} from 'react';
import {makeStyles} from '@material-ui/core';
import logo from './logo.svg';
import './App.css';

import {BrowserRouter, Switch, Route} from 'react-router-dom';
import Layout from './Layout';
import ConversationsView from './Views/ConversationsView';
import PersonView from './Views/PersonView';

const App = (props) => {
  const {theme} = props;
  //const classes = useStyles(theme);

  /*const pageNames = {
    AList : "A List",
    BList : "B List",
    CList : "C List",
  };

  const [selectedView,setSelectedView] = useState("List");
  
  

  const changePage = (pageName) => {
    console.log("changedPage: "+pageName);
    setSelectedView(pageName);
  }
  
  <Header changePage={changePage}/>
  <Page pageName={selectedView}/>
  
  */

  return (
    <BrowserRouter>
      <Layout>
        <Switch>
          <Route path="/conversations" render={() => <ConversationsView />} />
          <Route path="/person/:id" render={() => <PersonView />} />
        </Switch>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
