import { Container, Table } from "react-bootstrap";
import AddMenusContext from "../../components/shared/AddMenusContext";
import { useContext } from "react";

export default function CardEN() {
  const { menuCard } = useContext(AddMenusContext);

  let sum = 0;

  menuCard.forEach((element) => {
    sum += element.totalPrice;
  });

  return (
    <Container>
      <Container>
        <Table>
          <thead>
            <tr>
              <th>Id</th>
              <th>Typ menu</th>
              <th>Dzień</th>
              <th>Cena za dzień</th>
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
            <th>Do zapłaty: </th>
          </tr>
        </thead>
        <tbody>{sum}</tbody>
      </Table>
    </Container>
  );
}
