CREATE TABLE `osmanagerdb`.`servico` (
  `servico_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `descricao` VARCHAR(300) NOT NULL,
  `preco` FLOAT NOT NULL,
  PRIMARY KEY (`servico_id`)
);
