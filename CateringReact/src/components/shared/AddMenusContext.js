import { createContext, useState } from "react";

const AddMenusContext = createContext();

export const AddMenusContextProvider = ({ children }) => {
  const [menusIds, setMenusIds] = useState([]);
  const [menuCard, setMenuCard] = useState([]);

  function handleAdd(item) {
    var newItem = [
      {
        id: item.id,
      },
    ];
    const od = menusIds.concat(newItem);
    setMenusIds(od);

    var newItemCard = [
      {
        id: item.id,
        menuName: item.menuTypeName,
        totalPrice: item.totalPriceForOneDay,
        date: item.date,
      },
    ];
    const card = menuCard.concat(newItemCard);
    setMenuCard(card);
  }

  function handleResetCardAndMenusIdsList() {
    setMenusIds([]);
    setMenuCard([]);
  }

  return (
    <AddMenusContext.Provider
      value={{ menusIds, menuCard, handleAdd, handleResetCardAndMenusIdsList }}
    >
      {children}
    </AddMenusContext.Provider>
  );
};

export default AddMenusContext;
