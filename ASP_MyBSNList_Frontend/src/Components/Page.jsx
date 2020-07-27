import React, {useState,useEffect} from 'react';

import Grid from '@material-ui/core/Grid';

import axios from 'axios';

const Page = (props) => {

    const [pageName,setPageName] = useState(props.pageName);
    const [hello,setHello] = useState("");

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
        <Grid>
            <h1>{pageName}</h1>
            <h2>{hello}</h2>
        </Grid>
    );

}

export default Page;