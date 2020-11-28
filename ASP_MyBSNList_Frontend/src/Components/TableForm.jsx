import React, {useEffect, useCallback, useState} from 'react';
import PropTypes from 'prop-types';

import {
  Dialog, 
  DialogTitle,
  DialogActions,
  DialogContent,
  DialogContentText,
  TextField,
  Button,
  Select,
  Input,
  InputLabel,
  MenuItem,
  Box,
  makeStyles
} from '@material-ui/core/';

import {Alert, AlertTitle} from '@material-ui/lab/';

const DialogMode = {
  INPUT: 0,
  CONFIRM: 1,
  PROMPT: 2,
}

const TableFormFieldType = {
  TEXT : 0,
  SELECT: 1
}
const TableFormField = (props) => {
  const {
    id,
    label,
    type = TableFormFieldType.TEXT,
    defaultValue = "",
    items,
  } = props;

  return {id, label, type, defaultValue, items};
}

TableFormField.propTypes = {
  id: PropTypes.number.isRequired,
  label: PropTypes.string.isRequired,
}

const useStyles = makeStyles((theme) => ({
  fieldContainer: {
    marginTop: '10px',
  },
}));

const TableForm = (props) => {

    const {
      theme,
      title,
      body,
      error,
      handleAffirm,
      handleDeny,
      onClose,
      mode,
      fieldsInfo,
    } = props;

    const classes = useStyles(theme);
    const [isOpen,setIsOpen] = useState(props.isOpen);
    const [fields,setFields] = useState(props.fields);
    const [editState,setEditState] = useState(props.editState ?? {});

    const strings = 
    {
      INPUT_AFFIRM : "Confirm",
      CONFIRM_AFFIRM : "Yes",
      PROMPT_AFFIRM: "Ok",

      INPUT_DENY : "Cancel",
      CONFIRM_DENY : "No",
      PROMPT_DENY: "Cancel",
    }

    const handleAffirmClicked = (e) => {

      const itemsFields = fieldsInfo.filter(x => x.items);
      const newEditState = {...editState};
      
      itemsFields.forEach(x => {
        const fieldItems = itemsFields.find(y => y.id === x.id).items;
        const esValue = editState[x.id];

        newEditState[x.id] = fieldItems[esValue-1]?.Name ?? esValue;
      });

      handleAffirm?.(e,newEditState) ?? onClose();
    }

    const handleDenyClicked = (e) => {
      handleDeny?.(e,editState) ?? onClose();
    }

    const parseFormFields = useCallback(() => {
      
      const tryParseBool = (value) => {
        return value === 'true' || value === 'false' ? value === 'true' : value;
      }

      const handleFieldChanged = (e) => {

        const target = e.target;
  
        const newEditState = {
          ...editState, [target.id] : tryParseBool(target.value)
        }
  
        setEditState(newEditState);
      }

      const newFields = fieldsInfo?.map(x => {
          const fieldId = x.id.replace(' ','');
          const fieldLabel = x.label;
          const esValue = editState?.[fieldId] ?? x.items?.[0].Id ?? x.defaultValue;

          if(x.type === TableFormFieldType.TEXT) {
            return (
              <TextField
                key={fieldsInfo.indexOf(x)}
                id={fieldId}
                label={fieldLabel}
                type={Object.keys(TableFormFieldType)[x.type].toLowerCase()}
                onChange={handleFieldChanged}
                defaultValue={esValue ?? ''}
              />
            )
          } 
          else if (x.type === TableFormFieldType.SELECT) {

            editState[fieldId] = esValue ?? -1;

            const castSelectValue = (value) => {
              return x.items.find(y => y.Name === value || y.Id === value).Id;
            }
            
            return (
              <Box key={fieldId+" container"} className={classes.fieldContainer}>
                <InputLabel htmlFor={fieldId}>{fieldLabel}</InputLabel>
                <Select
                  key={fieldsInfo.indexOf(x)}
                  label={fieldLabel}
                  value={castSelectValue(esValue) ?? 1}
                  id={fieldId}
                  input={<Input id={fieldId}/>}
                  onChange={(e) => {
                    e.target.id = fieldId;
                    handleFieldChanged(e);
                  }}
                  defaultValue={x.defaultValue}
                >
                  {x.items.map(y => (<MenuItem key={y.Id} value={y.Id} name={fieldId}>
                      {y.Name}
                    </MenuItem>
                  ))}
                </Select>
              </Box>
            )
          }
          else {
            //unknown field type
          }
      }) ?? [];

      setFields(newFields);
    },[setFields,classes.fieldContainer,fieldsInfo,editState]);

    useEffect(() => {
      setIsOpen(props.isOpen);
      setEditState(props.editState);
      console.log("effect external");
    },[props.isOpen,props.editState]);

    useEffect(() => {
      parseFormFields();
      console.log("effect internal");
    },[parseFormFields,editState])

    return (
      <Dialog open={isOpen} onClose={handleDeny}>
        <DialogTitle>{title}</DialogTitle>
        <DialogContent>
              {error && 
                <Alert severity="error">
                  <AlertTitle>Error</AlertTitle>
                  {error}
                </Alert>
              }
            <DialogContentText>{body}</DialogContentText>
            {fields?.map(x => x)}
            
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

export default TableForm;
export { TableFormField,TableFormFieldType, DialogMode };