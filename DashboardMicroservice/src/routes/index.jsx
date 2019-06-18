import React from 'react';
import { Route, Switch, Redirect, withRouter } from 'react-router-dom';
import { Loader } from 'semantic-ui-react';
import Loadable from 'react-loadable';
import AppLayout from '../components/AppLayout';

const dynamicImport = loader =>
  Loadable({
    loader,
    loading: () => <Loader active inline="centered" />,
  });

const LoggedOutList = () => (
  <Switch>
    <Route exact path="/" component={dynamicImport(() => import('../pages/Dashboard'))} />
    <Redirect to="/" />
  </Switch>
);

const Routes = () => (
  <AppLayout>
    <LoggedOutList />
  </AppLayout>
);

export default withRouter(Routes);
