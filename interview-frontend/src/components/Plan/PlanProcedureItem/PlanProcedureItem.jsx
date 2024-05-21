import React, { useState } from "react";
import { useParams } from "react-router-dom";
import ReactSelect from "react-select";
import { addUserToProcedure } from "../../../api/api";

const PlanProcedureItem = ({ procedure, users, selectedUsersList }) => {
  let { id } = useParams();
  const [selectedUsers, setSelectedUsers] = useState(selectedUsersList);

  const handleAssignUserToProcedure = (e) => {
    // TODO: Remove console.log and add missing logic
    setSelectedUsers([]);
    const usersArr = [];
    const tempSelUsers = [];
    e.forEach((user) => {
      usersArr.push({
        planId: parseInt(id),
        procedureId: procedure.procedureId,
        userId: user.value,
      });
      tempSelUsers.push({
        label: user.label,
        value: user.value,
      });
    });
    setSelectedUsers(tempSelUsers);
    addUserToProcedure({ Users: usersArr });
  };
  return (
    <div className="py-2">
      <div>{procedure.procedureTitle}</div>

      <ReactSelect
        className="mt-2"
        placeholder="Select User to Assign"
        isMulti={true}
        options={users}
        value={selectedUsers}
        onChange={(e) => handleAssignUserToProcedure(e)}
      />
    </div>
  );
};

export default PlanProcedureItem;
