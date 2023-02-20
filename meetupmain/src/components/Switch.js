import * as React from "react";
import FormGroup from "@mui/material/FormGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import { Switch as MuiSwitch } from "@mui/material";

export default function Switch() {
  const dotNet = "http://localhost:7163";
  const nodeJs = "http://localhost:8080";

  const [switchState, setSwitchState] = React.useState(
    localStorage.getItem("url") === nodeJs
  );

  const handleChange = async (e) => {
    setSwitchState(!switchState);
    if (switchState) {
      localStorage.setItem("url", dotNet);
      localStorage.removeItem("access_token");
      window.location.reload();
    } else {
      localStorage.setItem("url", nodeJs);
      localStorage.removeItem("access_token");
      window.location.reload();
    }
  };
  return (
    <FormGroup>
      <FormControlLabel
        control={<MuiSwitch onChange={handleChange} checked={switchState} />}
        label="Nodejs"
      />
    </FormGroup>
  );
}
