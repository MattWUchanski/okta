export default {
  oidc: {
    clientId: '0oa9vrflqgqxTPGW65d7',
    issuer: 'https://dev-56634461.okta.com/oauth2/default',
    redirectUri: window.location.origin + '/login/callback',
    scopes: ['openid', 'profile', 'email']
  }
}
