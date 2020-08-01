import React, {useState} from 'react';

import {Dialog, DialogTitle} from '@material-ui/core/';
import InputLabel from '@material-ui/core/InputLabel';
import Input from '@material-ui/core/Input';

const NewPersonForm = (props) => {

    const loadData = async () => {

    }

    return (
        <Dialog open={props.open}>
            <DialogTitle id="form-dialog-title">Add Person</DialogTitle>
            {/*<DialogContent>
              <DialogContentText>
                Enter some details about them
              </DialogContentText>
              <TextField
                autoFocus
                margin="dense"
                id="name"
                label="Name"
                type="email"
                fullWidth
              />
            </DialogContent>
            <DialogActions>
              <Button onClick={handleClose} color="primary">
                Cancel
              </Button>
              <Button onClick={handleClose} color="primary">
                Subscribe
              </Button>
            </DialogActions>*/}
        </Dialog>
    )
}

export default NewPersonForm;