import React, {useEffect, useCallback, useState} from 'react';
import PropTypes from 'prop-types';

import {
  Dialog, 
  DialogTitle,
  DialogActions,
  DialogContent,
  DialogContentText,
  TextField,
  Button
} from '@material-ui/core/';

const DialogMode = {
  INPUT: 0,
  CONFIRM: 1,
  PROMPT: 2,
}

const TableFormField = (props) => {

}

const TableForm = (props) => {

    const {
      title,
      body,
      handleAffirm,
      handleDeny,
      onClose,
      mode,
      fieldsInfo,
    } = props;

    const [isOpen,setIsOpen] = useState(props.isOpen);
    const [fields,setFields] = useState(props.fields);

    const strings = 
    {
      INPUT_AFFIRM : "Confirm",
      CONFIRM_AFFIRM : "Yes",
      PROMPT_AFFIRM: "Ok",

      INPUT_DENY : "Cancel",
      CONFIRM_DENY : "No",
      PROMPT_DENY: "Cancel",
    }

    const parseFormFields = useCallback(() => {
      
      const newFields = fieldsInfo?.map(x => {

      }) ?? [];

      setFields(newFields);
    },[setFields]);

    useEffect(() => {
      //loadData();
      parseFormFields();
      setIsOpen(props.isOpen);
    },[parseFormFields,props.isOpen,props.fields]);

    const handleAffirmClicked = (e) => {
      handleAffirm?.(e) ?? onClose();
    }

    const handleDenyClicked = (e) => {
      handleDeny?.(e) ?? onClose();
    }

    return (
      <Dialog open={isOpen}>
        <DialogTitle>{title}</DialogTitle>
        <DialogContent>
            <DialogContentText>{body}</DialogContentText>
            <TextField 
            autoFocus
            id="name"
            label ="Name"
            type='text'
            />
            
        </DialogContent>
        <DialogActions>
            <Button onClick={handleAffirmClicked} color="primary">
              {(mode === DialogMode.INPUT) && strings.INPUT_AFFIRM}
              {(mode === DialogMode.CONFIRM) && strings.CONFIRM_AFFIRM}
              {(mode === DialogMode.PROMPT) && strings.PROMPT_AFFIRM}
            </Button>
            <Button onClick={handleDenyClicked} color="primary">
              {(mode === DialogMode.INPUT) && strings.INPUT_DENY}
              {(mode === DialogMode.CONFIRM) && strings.CONFIRM_DENY}
              {(mode === DialogMode.PROMPT) && strings.PROMPT_DENY}
            </Button>
        </DialogActions>
      </Dialog>
    )
}

TableForm.propTypes = {
  onClose : PropTypes.func.isRequired,
}

TableForm.defaultProps = {
  mode : DialogMode.INPUT,
}

export {TableForm,TableFormField, DialogMode};