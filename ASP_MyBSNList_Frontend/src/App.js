import React, {useState} from 'react';
import logo from './logo.svg';
import './App.css';

import Header from './Components/Header';
import Page from './Components/Page';

function App() {

  const pageNames = {
    AList : "A List",
    BList : "B List",
    CList : "C List",
  };

  const [selectedView,setSelectedView] = useState("List");
  
  

  const changePage = (pageName) => {
    console.log("changedPage: "+pageName);
    setSelectedView(pageName);
  }

  return (
    <div className="App">
      <Header changePage={changePage}/>
      <Page pageName={selectedView}/>
    </div>
  );
}

export default App;
