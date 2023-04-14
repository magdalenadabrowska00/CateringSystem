import { Container, Table } from "react-bootstrap";
import AddMenusContext from "../../components/shared/AddMenusContext";
import { useContext } from "react";

export default function CardTable() {
  const { menuCard } = useContext(AddMenusContext);

  const totalCardPrice = () => {
    let sum = 0;
    for (let i = 0; i < menuCard.length; i++) {
      sum += menuCard[i].totalPrice;
    }
    return sum;
  };
  console.log(totalCardPrice);

  return (
    <Container>
      <Container>
        <Table>
          <thead>
            <tr>
              <th>Id</th>
              <th>Menu type name</th>
              <th>Date</th>
              <th>Price by day</th>
            </tr>
          </thead>
          <tbody>
            {menuCard.map((item) => (
              <tr>
                <td>{item.id}</td>
                <td>{item.menuName}</td>
                <td>{item.date}</td>
                <td>{item.totalPrice}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Container>
      <Table>
        <thead>
          <tr>
            <th>Total price: </th>
          </tr>
        </thead>
        <tbody>{totalCardPrice}</tbody>
      </Table>
    </Container>
  );
}
