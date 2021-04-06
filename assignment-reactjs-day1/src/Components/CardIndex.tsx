import React from 'react';
import { Card, Button } from 'react-bootstrap';
import './Card.css';
import { FoodList } from '../Foodlist';
import { faCheck, faTimes } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

interface CardProp {
  text: string;
  price: number;
  desc: string;
  list?: FoodList[];
}

function CardIndex(props: CardProp) {
  const { text, price, desc, list = [] } = props;
  return (
    <div>
      <Card bg='light' style={{ width: '20rem' }}>
        <Card.Body>
          <Card.Title>
            <h1 className='text-color'>{text}</h1>
          </Card.Title>
          <Card.Text>
            <h2 className='price-color'>{price}$</h2>
            <p className='desc-color'>{desc}</p>
          </Card.Text>
        </Card.Body>
        {list.map((item) => (
          <div key={item.name}>
            {item.flag ? (
              <span>
                <FontAwesomeIcon icon={faCheck} />
              </span>
            ) : (
              <span>
                <FontAwesomeIcon icon={faTimes} />
              </span>
            )}
              <span style={!item.flag ? { opacity: 0.3 } : { opacity: 1 }}>&ensp;{item.name}</span>
          </div>
        ))}
        <Card.Body>
          <Button variant='dark' size='lg' block>
            Buy now
          </Button>
        </Card.Body>
      </Card>
    </div>
  );
}
export default CardIndex;
