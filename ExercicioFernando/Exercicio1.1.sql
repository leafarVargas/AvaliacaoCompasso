SELECT cliente.nome AS "Nome do Cliente", cliente.idade AS "Idade do Cliente", dependente.nome AS "Nome do Dependente",dependente.idade AS "Idade do Dependente" 
FROM cliente, dependente, tipo_cliente 
WHERE tipo_cliente.descricao = 'FIDELIZADO' AND cliente.id = dependente.id_cliente;

SELECT cliente.nome AS "Nome do Cliente", cliente.id AS "Id do Cliente" 
FROM cliente
WHERE cliente.id NOT IN ( SELECT dependente.id_cliente FROM dependente);

SELECT dependente.nome AS "Nome do Dependente", cliente.nome AS "Nome do Cliente" 
FROM cliente, dependente
WHERE dependente.id_cliente = cliente.id AND cliente.nome LIKE '%AR%';