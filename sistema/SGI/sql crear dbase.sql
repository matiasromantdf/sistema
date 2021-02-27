create table GASTOS
(
    ID_GASTO             INTEGER               not null identity,
    FECHA_GASTO          date                  not null,
    MONTO_GASTO          DECIMAL(8,2)                  ,
    DETALLE_GASTO        VARCHAR(100)                  ,
    primary key (ID_GASTO)
);

create unique index GASTOS_PK on GASTOS (ID_GASTO asc);

create table CAJA
(
    ID_MOV_CAJA          INTEGER               not null identity,
    ACTUAL_CAJA          DECIMAL(8,2)                  ,
    ACTUAL_COSTO         DECIMAL(8,2)                  ,
    ACTUAL_GANANCIA      DECIMAL(8,2)                  ,
    primary key (ID_MOV_CAJA)
);

create unique index CAJA_PK on CAJA (ID_MOV_CAJA asc);

create table VENTAS
(
    ID_VENTA             INTEGER               not null identity,
    FECHA_VENTA          DATE                          ,
    FACTURA              VARCHAR(50)                   ,
    MONTO_VENTA          DECIMAL(8,2)                  ,
    primary key (ID_VENTA)
);

create unique index VENTAS_PK on VENTAS (ID_VENTA asc);

create table PROVEEDORES
(
    ID_PROVEEDOR         INTEGER               not null identity,
    CC_PROVEEDOR         DECIMAL(8,2)                  ,
    NOMBRE_PROVEEDOR     VARCHAR(50)                   ,
    primary key (ID_PROVEEDOR)
);

create unique index PROVEEDORES_PK on PROVEEDORES (ID_PROVEEDOR asc);

create table ARTICULOS
(
    COD_ARTICULO         VARCHAR(100)          not null,
    ID_PROVEEDOR         INTEGER               not null,
    DESCR_ARTICULO       VARCHAR(50)           not null,
    COSTO_ARTICULO       DECIMAL(8,2)          not null,
    PRECIO_ARTICULO      DECIMAL(8,2)          not null,
    STOCK_ARTICULO       INTEGER               not null,
    REPOSICION_ARTICULO  INTEGER                       ,
    IVA                  DECIMAL(4,2)                  ,
    primary key (COD_ARTICULO),
    foreign key  (ID_PROVEEDOR)
       references PROVEEDORES (ID_PROVEEDOR)
);

create unique index ARTICULOS_PK on ARTICULOS (COD_ARTICULO asc);

create index PROVEEDOR_EN_ARTICULOS_FK on ARTICULOS (ID_PROVEEDOR asc);

create table COMPRA
(
    ID_COMPRA            INTEGER               not null identity,
    ID_PROVEEDOR         INTEGER               not null,
    NUM_FACTURA          VARCHAR(50)                   ,
    FECHA_COMPRA         DATE                          ,
    MONTO_COMPRA         DECIMAL(8,2)                  ,
    primary key (ID_COMPRA),
    foreign key  (ID_PROVEEDOR)
       references PROVEEDORES (ID_PROVEEDOR)
);

create unique index COMPRA_PK on COMPRA (ID_COMPRA asc);

create index RELATION_207_FK on COMPRA (ID_PROVEEDOR asc);

create table DETALLE_VENTA
(
    ID_VENTA             INTEGER               not null,
    COD_ARTICULO         VARCHAR(100)          not null,
    CANT_ARTIC_VENTA     INTEGER                       ,
    SUBTOTAL             DECIMAL(8,2)                  ,
    primary key (ID_VENTA, COD_ARTICULO),
    foreign key  (ID_VENTA)
       references VENTAS (ID_VENTA),
    foreign key  (COD_ARTICULO)
       references ARTICULOS (COD_ARTICULO)
);

create unique index DETALLE_VENTA_PK on DETALLE_VENTA (COD_ARTICULO asc, ID_VENTA asc);

create index VENTA_DETALLE_VENTA_FK on DETALLE_VENTA (ID_VENTA asc);

create index ARTICULOS_EN_DETALLEVENTA_FK on DETALLE_VENTA (COD_ARTICULO asc);

create table DETALLE_COMPRA
(
    ID_COMPRA            INTEGER               not null,
    COD_ARTICULO         VARCHAR(100)          not null,
    COSTO                DECIMAL(8,2)                  ,
    PRECIO               DECIMAL(8,2)                  ,
    CANT_COMPRA          INTEGER                       ,
    primary key (ID_COMPRA, COD_ARTICULO),
    foreign key  (ID_COMPRA)
       references COMPRA (ID_COMPRA),
    foreign key  (COD_ARTICULO)
       references ARTICULOS (COD_ARTICULO)
);

create unique index DETALLE_COMPRA_PK on DETALLE_COMPRA (ID_COMPRA asc, COD_ARTICULO asc);

create index RELATION_208_FK on DETALLE_COMPRA (ID_COMPRA asc);

create index RELATION_209_FK on DETALLE_COMPRA (COD_ARTICULO asc);

create table BAJAS
(
    COD_ARTICULO         VARCHAR(100)               not null,
    DETALLE              VARCHAR(100)                  ,
    CANTIDAD             INTEGER                       ,
    FECHA_BAJA           DATE                          ,
    ID_BAJA              INTEGER               not null identity,
    primary key (ID_BAJA),
    foreign key  (COD_ARTICULO)
       references ARTICULOS (COD_ARTICULO)
);

create unique index BAJAS_PK on BAJAS (ID_BAJA asc);

create index RELATION_315_FK on BAJAS (COD_ARTICULO asc);

create table PAGOS
(
	ID_PAGO		         INTEGER               not null IDENTITY,
    ID_PROVEEDOR         INTEGER               not null,
    FECHA                DATE                          ,
    COMPROBANTE_PAGO     VARCHAR(100)                  ,
    MONTO_PAGO           DECIMAL(8,2)                  ,
    foreign key  (ID_PROVEEDOR)
       references PROVEEDORES (ID_PROVEEDOR)
);

create unique index PAGOS_PK on PAGOS (ID_PROVEEDOR asc);

