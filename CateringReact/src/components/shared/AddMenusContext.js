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
      },
    ];
    const card = menuCard.concat(newItemCard);
    setMenuCard(card);
  }
  console.log(menusIds);
  console.log(menuCard);

  return (
    <AddMenusContext.Provider value={{ menusIds, menuCard, handleAdd }}>
      {children}
    </AddMenusContext.Provider>
  );
};

export default AddMenusContext;
