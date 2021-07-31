import React, { Component } from 'react';
import Grid from './components/Grid'
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Grid />
    );
  }
}
