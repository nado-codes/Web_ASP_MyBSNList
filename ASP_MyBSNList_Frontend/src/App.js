import React, {useState} from 'react';
import logo from './logo.svg';
import './App.css';

import Header from './Components/Header';
import Page from './Components/Page';

function App() {

  const [selectedView,setSelectedView] = useState("aList");
  
  const pageNames = {
    aList : "A List",
    bList : "B List",
    cList : "C List",
  };

  return (
    <div className="App">
      <Header/>
      <Page pageName={pageNames[selectedView]}/>
    </div>
  );
}

export default App;
