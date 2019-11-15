import { Application } from "express";
import * as Keycloak from "keycloak-connect";

import CharactersServiceImpl from './impl/characters.service';
import NewsArticlesServiceImpl from './impl/newsArticles.service';

export default class Api {

  /**
   * Constructor
   * 
   * @param app Express app
   * @param keycloak Keycloak
   */
  constructor(app: Application, keycloak: Keycloak) {
    
      new CharactersServiceImpl(app, keycloak);
    
      new NewsArticlesServiceImpl(app, keycloak);
    
  }
}
