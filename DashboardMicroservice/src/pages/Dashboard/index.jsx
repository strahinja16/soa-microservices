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
import Segment from '../../components/elements/Segment';
import SubHeader from '../../components/elements/SubHeader';
import pusherService from '../../services/pusher';
import { addApplication } from '../../reducers/application';
import { addAddress } from '../../reducers/address';
import { addBluetooth } from '../../reducers/bluetooth';
import { addLocation } from '../../reducers/location';
import { addWifi } from '../../reducers/wifi';
import { addCall } from '../../reducers/call';

class Dashboard extends Component {
  componentDidMount() {
    const {
      getApplicationsAction,
      getBluetoothsAction,
      getCallsAction,
      getLocationsAction,
      getWifisAction,
      getAddressesAction,
      addApplicationAction,
      addAddressAction,
      addBluetoothAction,
      addLocationAction,
      addWifiAction,
      addCallAction,
    } = this.props;

    getApplicationsAction();
    getBluetoothsAction();
    getCallsAction();
    getLocationsAction();
    getWifisAction();
    getAddressesAction();

    pusherService.subscribe('application', 'add', addApplicationAction);
    pusherService.subscribe('address', 'add', addAddressAction);
    pusherService.subscribe('bluetooth', 'add', addBluetoothAction);
    pusherService.subscribe('location', 'add', addLocationAction);
    pusherService.subscribe('wifi', 'add', addWifiAction);
    pusherService.subscribe('call', 'add', addCallAction);
  }

  componentWillUnmount() {
    pusherService.unsubscribe('application');
    pusherService.unsubscribe('address');
    pusherService.unsubscribe('bluetooth');
    pusherService.unsubscribe('location');
    pusherService.unsubscribe('wifi');
    pusherService.unsubscribe('call');
  }

  render() {
    const {
      applications, bluetooths, calls, locations, wifis, addresses,
    } = this.props;
    if (!bluetooths && !calls && !applications && !locations && !addresses && !wifis) {
      return null;
    }

    return (
      <Fragment>
        <Segment>
          <SubHeader header="Bluetooth bonds" />
          <BluetoothBonds list={bluetooths} />
        </Segment>
        <Segment>
          <SubHeader header="Application process counts" />
          <ApplicationProcessCounts list={applications} />
        </Segment>
        <Segment>
          <SubHeader header="Call durations" />
          <CallDurations list={calls} />
        </Segment>
        <Segment>
          <SubHeader header="Location accuracies" />
          <LocationAccuracies list={locations} />
        </Segment>
        <Segment>
          <SubHeader header="Address counts" />
          <AddressCounts list={addresses} />
        </Segment>
        <Segment>
          <SubHeader header="Wifi capabilities" />
          <WifiCapabilities list={wifis} />
        </Segment>
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
    addApplicationAction: addApplication,
    addAddressAction: addAddress,
    addBluetoothAction: addBluetooth,
    addLocationAction: addLocation,
    addWifiAction: addWifi,
    addCallAction: addCall,
  },
  dispatch,
);

export default withRouter(
  connect(
    mapStateToProps,
    mapDispatchToProps,
  )(Dashboard),
);
