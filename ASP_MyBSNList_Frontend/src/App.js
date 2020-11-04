import React from 'react';
import './App.css';

import {BrowserRouter, Switch, Route} from 'react-router-dom';
import Layout from './Layout';
import ConversationsView from './Views/ConversationsView';
import PersonView from './Views/PersonView';
import ListView from './Views/ListView';

const App = (props) => {
  
  return (
    <BrowserRouter>
      <Layout>
        <Switch>
          <Route path="/conversations" render={() => <ConversationsView />} />
          <Route path="/person/:id" render={() => <PersonView />} />
          <Route path="/list" render={() => <ListView/>} />
        </Switch>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
