1. Devuelve un listado con el nombre de los todos los clientes españoles.
``` c#
    http://localhost:5181/api/Cliente/GetSpanishCustomersNames
```

2. Devuelve un listado con los distintos estados por los que puede pasar un pedido.
``` c#
    http://localhost:5181/api/Pedido/GetOrderstates
```

3. Devuelve un listado con el código de cliente de aquellos clientes que realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar aquellos códigos de cliente que aparezcan repetidos.
``` c#
    http://localhost:5181/api/Pago/GetCustomersIdWhoPayIn2008
```

4. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
``` c#
    http://localhost:5181/api/Pedido/GetBackOrders
```

5. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al menos dos días antes de la fecha esperada.
``` c#
    http://localhost:5181/api/Pedido/GetOrdersTwoDaysEarlier
```

6. Devuelve un listado de todos los pedidos que fueron rechazados en 2009.
``` c#
    http://localhost:5181/api/Pedido/GetRejectedOrdersIn2009
```

7. Devuelve un listado de todos los pedidos que han sido entregados en el mes de enero de cualquier año.
``` c#
    http://localhost:5181/api/Pedido/GetOrdersInJanuary
```

8. Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor.
``` c#
    http://localhost:5181/api/Pago/GetPaymentsOrderedIn2008
```

9. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas.
``` c#
    http://localhost:5181/api/Pago/GetPaymentsOrderedIn2008
```

10. Devuelve un listado con todos los productos que pertenecen a la gama Ornamentales y que tienen más de 100 unidades en stock. El listado deberá estar ordenado por su precio de venta decendente
``` c#
    http://localhost:5181/api/Producto/GetProductsOrnamentalsWithMoreThan100Ordered
```

11. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y cuyo representante de ventas tenga el código de empleado 11 o 30.
``` c#
    http://localhost:5181/api/Cliente/GetClientsFromMadridWithEmployeeRepresentant30Or11
```

12. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su representante de ventas.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWithRepSalInfo
```

13. Muestra el nombre de los clientes que hayan realizado pagos junto con el nombre de sus representantes de ventas.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWithRepSalInfoIfHavePayments
```

14. Muestra el nombre de los clientes que no hayan realizado pagos junto con el nombre de sus representantes de ventas.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWithRepSalInfoIfDontHavePayments
```

15. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWithRepSalInfoIfHavePaymentsPlusOfficeCity
```

16. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWithRepSalInfoIfDontHavePaymentsPlusOfficeCity
```

17. Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
``` c#
    http://localhost:5181/api/Empleado/GetEmployeeWithBossWithBoss
```

18. Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.
``` c#
    http://localhost:5181/api/Cliente/GetClientsWhoHaveReceivedABackorder
```

19. Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente.
``` c#
    http://localhost:5181/api/Cliente/RangesPurchasedByEachCustomer
```

20. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
``` c#
    http://localhost:5181/api/Cliente/CustomersWhoHaveNotMadePayments
```

21. Devuelve un listado que muestre los clientes que no han realizado ningún pago y los que no han realizado ningún pedido.
``` c#
    http://localhost:5181/api/Cliente/CustomersWhoHaveNotMadePaymentsOrPlacedOrders
```

22. Devuelve un listado que muestre solamente los empleados que no tienen un cliente asociado junto con los datos de la oficina donde trabajan.
``` c#
    http://localhost:5181/api/Empleado/EmployeesWhoHaveNoAssociatedCustomersWithOffice
```

23. Devuelve un listado que muestre los empleados que no tienen una oficina asociada y que no tienen un cliente asociado.
``` c#
    http://localhost:5181/api/Empleado/EmployeesWithoutOfficeNorCustomers
```

24. Devuelve un listado de los productos que nunca han aparecido en un pedido.
``` c#
    http://localhost:5181/api/Empleado/EmployeesWithoutOfficeNorCustomers
```

25. Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
``` c#
    http://localhost:5181/api/Producto/ProductsThatHaveNeverBeenOrderedNameDescAndImg
```

26. Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
``` c#
    http://localhost:5181/api/Oficina/OfficesWhereEmployeesOfCustomersWhoPurchaseFruitProductsDontWork
```

27. Devuelve un listado con los clientes que han realizado algún pedido pero no han realizado ningún pago.
``` c#
    http://localhost:5181/api/Cliente/CustomersWithOrdersButNotPayments
```

28. Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
``` c#
    http://localhost:5181/api/Empleado/EmployeesWithoutClientsPlusBossName
```

29. ¿Cuántos empleados hay en la compañía?
``` c#
    http://localhost:5181/api/Empleado/HowManyEmployeesAreInTheCompany
```

30. ¿Cuántos clientes tiene cada país?
``` c#
    http://localhost:5181/api/Cliente/HowManyCustomersPerCountry
```

31. ¿Cuál fue el pago medio en 2009?
``` c#
    http://localhost:5181/api/Pago/AveragePaymentIn2009
```

32. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
``` c#
    http://localhost:5181/api/Pedido/HowManyOrdersByState
```

33. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid?
``` c#
    http://localhost:5181
```

34. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M?
``` c#
    http://localhost:5181
```

35. Devuelve el nombre de los representantes de ventas y el número de clientes al que atiende cada uno.
``` c#
    http://localhost:5181
```

36. Calcula el número de clientes que no tiene asignado representante de ventas.
``` c#
    http://localhost:5181
```

37. Calcula la fecha del primer y último pago realizado por cada uno de los clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente.
``` c#
    http://localhost:5181
```

38. Calcula el número de productos diferentes que hay en cada uno de los pedidos.
``` c#
    http://localhost:5181
```

39. Calcula la suma de la cantidad total de todos los productos que aparecen en cada uno de los pedidos.
``` c#
    http://localhost:5181
```

40. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
``` c#
    http://localhost:5181
```

41. La misma información que en la pregunta anterior, pero agrupada por código de producto.
``` c#
    http://localhost:5181
```

42. La misma información que en la pregunta anterior, pero agrupada por código de producto filtrada por los códigos que empiecen por OR.
``` c#
    http://localhost:5181
```

43. Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
``` c#
    http://localhost:5181
```

44. Muestre la suma total de todos los pagos que se realizaron para cada uno de los años que aparecen en la tabla pagos.
``` c#
    http://localhost:5181
```

45. Devuelve el nombre del cliente con mayor límite de crédito.
``` c#
    http://localhost:5181
```

46. Devuelve el nombre del producto que tenga el precio de venta más caro.
``` c#
    http://localhost:5181
```

47. Devuelve el nombre del producto del que se han vendido más unidades. (Tenga en cuenta que tendrá que calcular cuál es el número total de unidades que se han vendido de cada producto a partir de los datos de la tabla detalle_pedido)
``` c#
    http://localhost:5181
```

48. Los clientes cuyo límite de crédito sea mayor que los pagos que haya realizado. (Sin utilizar INNER JOIN).
``` c#
    http://localhost:5181
```

49. Devuelve el nombre del cliente con mayor límite de crédito.
``` c#
    http://localhost:5181
```

50. Devuelve el nombre del producto que tenga el precio de venta más caro.
``` c#
    http://localhost:5181
```

51. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
``` c#
    http://localhost:5181
```

52. Devuelve un listado que muestre solamente los clientes que sí han realizado algún pago.
``` c#
    http://localhost:5181
```

53. Devuelve un listado de los productos que nunca han aparecido en un pedido.
``` c#
    http://localhost:5181
```

54. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente
``` c#
    http://localhost:5181
```

55. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
``` c#
    http://localhost:5181
```

56. Devuelve un listado que muestre solamente los clientes que sí han realizado algún pago.
``` c#
    http://localhost:5181
```

57. Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no han realizado ningún pedido.
``` c#
    http://localhost:5181
```

58. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008 ordenados alfabéticamente de menor a mayor.
``` c#
    http://localhost:5181
```

59. Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
``` c#
    http://localhost:5181
```

60. Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
``` c#
    http://localhost:5181
```

61. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente.
``` c#
        http://localhost:5181
```