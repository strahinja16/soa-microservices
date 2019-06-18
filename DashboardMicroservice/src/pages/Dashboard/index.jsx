/* eslint-disable react/prop-types */

import React, { Component, Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { getApplications } from '../../thunks/application';
import { getBluetooths } from '../../thunks/bluetooth';
import { getCalls } from '../../thunks/call';
import ApplicationProcessCounts from '../../components/Tables/ApplicationProcessCounts';
import BluetoothBonds from '../../components/Tables/BluetoothBonds';
import CallDurations from '../../components/Tables/CallDurations';
import { getAddresses } from '../../thunks/address';
import { getLocations } from '../../thunks/location';
import { getWifis } from '../../thunks/wifi';
import AddressCounts from '../../components/Tables/AddressCounts';
import LocationAccuracies from '../../components/Tables/LocationAccuracies';
import WifiCapabilities from '../../components/Tables/WifiCapabilities';

class Dashboard extends Component {
  componentDidMount() {
    const { getApplicationsAction, getBluetoothsAction, getCallsAction } = this.props;

    getApplicationsAction();
    getBluetoothsAction();
    getCallsAction();
  }

  render() {
    const {
      applications, bluetooths, calls, addresses, locations, wifis,
    } = this.props;
    if (!applications || !bluetooths || !calls || !addresses || !locations || !wifis) {
      return null;
    }

    return (
      <Fragment>
        <ApplicationProcessCounts list={applications} />
        <BluetoothBonds list={bluetooths} />
        <CallDurations list={calls} />
        <AddressCounts list={calls} />
        <LocationAccuracies list={calls} />
        <WifiCapabilities list={calls} />
      </Fragment>
    );
  }
}

const mapStateToProps = ({
  application, bluetooth, call, address, location, wifi,
}) => ({
  applications: application.get('applications'),
  bluetooths: bluetooth.get('bluetooths'),
  calls: call.get('calls'),
  addresses: address.get('addresses'),
  locations: location.get('locations'),
  wifis: wifi.get('wifis'),
});

const mapDispatchToProps = dispatch => bindActionCreators(
  {
    getApplicationsAction: getApplications,
    getBluetoothsAction: getBluetooths,
    getCallsAction: getCalls,
    getAddressesAction: getAddresses,
    getLocationsAction: getLocations,
    getWifisAction: getWifis,
  },
  dispatch,
);

export default withRouter(
  connect(
    mapStateToProps,
    mapDispatchToProps,
  )(Dashboard),
);
