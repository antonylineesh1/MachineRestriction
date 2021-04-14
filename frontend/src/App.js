import React, { useState } from 'react';
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { Button, Container, Row, Col } from 'react-bootstrap';
const { ipcRenderer } = window.require('electron');



function App() {
  // setInterval(() => {
  //   ipcRenderer.send('asynchronous-message', 'ping');
  // }, 1000);
  const [email, setEmail] = useState('');
  const [isSuccess, setStatus] = useState(false);

  const synchMachineinfo = () => {
    ipcRenderer.send('asynchronous-message', email);
  }

  ipcRenderer.on('machine-info-response', (event, response) => {
    console.log("In update-machine response");
    console.log(response);

    if (response && Array.isArray(response)) {
      if (response[0].Success = 'Success') {
        setStatus(true);
      }
    }
    else {
      setStatus(false);
    }
  });

  return (
    <div className="App">
      <header className="App-header">
        <Container>
          <Row>
            <Col xs={8}><input type="text" placeholder="enter email address" onChange={(e) => setEmail(e.target.value)} /></Col>
            <Col>
              <Button variant="primary" onClick={synchMachineinfo}>Click</Button>
            </Col>
          </Row>
          <Row>
            {isSuccess ? <Button variant="success">Success</Button> : <Button variant="danger">Failed</Button>}
          </Row>
        </Container>

      </header>
    </div>
  );
}

export default App;
