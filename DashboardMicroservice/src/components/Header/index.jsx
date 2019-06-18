
import React, { Component } from 'react';
import {
  Menu, MenuItem, Container, Segment,
} from 'semantic-ui-react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import style from './styles.scss';

class Header extends Component {
  constructor(props) {
    super(props);

    this.itemChangeCallback = this.itemChangeCallback.bind(this);
  }

  itemChangeCallback(url) {
    const { activeItem, onItemChange } = this.props;
    if (activeItem === url) {
      return;
    }
    onItemChange(url);
  }

  leftMenu() {
    return (
      <React.Fragment>
        <MenuItem name="home" onClick={() => this.itemChangeCallback('/')} />
      </React.Fragment>
    );
  }

  render() {
    const { className } = this.props;

    const segmentClass = classNames(style.segment, {
      [className]: className,
    });

    return (
      <Segment className={segmentClass}>
        <Menu pointing secondary size="large">
          <Container>
            {this.leftMenu()}
          </Container>
        </Menu>
      </Segment>
    );
  }
}

Header.defaultProps = {
  activeItem: '/',
  className: null,
};

Header.propTypes = {
  activeItem: PropTypes.string,
  className: PropTypes.string,
  onItemChange: PropTypes.func.isRequired,
};

export default Header;
