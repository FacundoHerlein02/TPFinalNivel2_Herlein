Select * from ARTICULOS
Select Id,Descripcion from MARCAS
Select Id,Descripcion from CATEGORIAS

--Corregida Selecciona datos de los Articulos
Select A.Id,Codigo,Nombre,A.Descripcion ,M.Descripcion Marca,M.Id idMarca,C.Descripcion Categoría,C.Id idCategoria,ImagenUrl,Precio from ARTICULOS A,MARCAS M,CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id

--Filtro
Select A.Id,Codigo,Nombre,A.Descripcion ,M.Descripcion Marca,M.Id idMarca,C.Descripcion Categoría,C.Id idCategoria,ImagenUrl,Precio from 
ARTICULOS A,MARCAS M,CATEGORIAS C 
where A.IdMarca=M.Id And A.IdCategoria=C.Id And ROUND(Precio,2)=70
--Insertar Registro
Insert Into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values()
--Insert Into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values('tw500','tw500','tw500',1,2,'https://dcdn.mitiendanube.com/stores/855/354/products/tw-500-bl1-4b9a762c95c99998d416274001914428-640-0.jpg',199)
--Actualiza registros
Update ARTICULOS Set Codigo=1 ,Nombre='Prueba',Descripcion='Probando Descrìpcion',IdMarca=2,IdCategoria=3,ImagenUrl='hola',Precio=1555 Where Id=10
--Elimina Registros
Delete ARTICULOS where Id=10